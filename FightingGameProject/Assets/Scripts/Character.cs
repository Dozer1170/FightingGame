using UnityEngine;
using System.Collections;

public class Character {
	
	public Character otherChar;
	public Vector3 pos;
	public bool inAir = false;
	public bool busy = false;
	public bool disableFall = false;
	protected SpriteManager sm;
	protected Sprite sprite;
	protected AnimSet animSet;
	protected float walkSpeed = 0.03f;
	protected float backpedalSpeed = 0.02f;
	protected float jumpUpSpeed = 0.17f;
	protected float jumpDec = 0.007f;
	protected float jumpForwardVelocity = 0.06f;
	protected float jumpBackwardVelocity = -0.05f;
	public float ySpeed;
	public float xSpeed;
	public int direction = 1;
	public int FORWARD = Inputs.RIGHT;
	public int BACKWARD = Inputs.LEFT;
	public int UPFORWARD = Inputs.UPRIGHT;
	public int UPBACK = Inputs.UPLEFT;
	public int DOWNFORWARD = Inputs.DOWNRIGHT;
	public int DOWNBACK = Inputs.DOWNLEFT;
	public int recoveryProgress;
	public int currRecovery = -1;
	public BoundingBox boundingBox = new BoundingBox();
	
	public Character() {
		
	}
	
	public Character(Vector3 pos, Sprite sprite, SpriteManager sm) {
		this.pos = pos;
		this.sprite = sprite;
		this.sm = sm;
		sprite.hidden = false;
		animSet = new AnimSet(sprite, sm);
	}
	
	public void SetOtherChar(Character otherChar) {
		this.otherChar = otherChar;	
	}
	
	public void FlipDirection() {
		if(direction == 1) {
			direction = -1;
			sprite.clientTransform.rotation = Quaternion.Euler(0,180,0);
			FORWARD = Inputs.LEFT;
			BACKWARD = Inputs.RIGHT;
			UPFORWARD = Inputs.UPLEFT;
			UPBACK = Inputs.UPRIGHT;
			DOWNFORWARD = Inputs.DOWNLEFT;
			DOWNBACK = Inputs.DOWNRIGHT;
		} else {
			direction = 1;
			sprite.clientTransform.rotation = Quaternion.Euler(0,0,0);
			FORWARD = Inputs.RIGHT;
			BACKWARD = Inputs.LEFT;
			UPFORWARD = Inputs.UPRIGHT;
			UPBACK = Inputs.UPLEFT;
			DOWNFORWARD = Inputs.DOWNRIGHT;
			DOWNBACK = Inputs.DOWNLEFT;	
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (inAir) {
			if(disableFall) {
				Move (xSpeed, 0);
			} else {	
				ySpeed -= jumpDec;
				if (pos.y - boundingBox.bottom + ySpeed > Game.groundHeight) {
						Move (xSpeed, ySpeed);
				} else {
					Landed();
				}
			}
		}
		
		if(currRecovery != -1) {
			if(recoveryProgress < currRecovery) {
				recoveryProgress++;	
			}
			else  {
				currRecovery = -1;
				recoveryProgress = 0;
			}
		}
	}
	
	public void TryCheckInput(bool[,] buffer) {
		if(!busy && currRecovery == -1) {
			CheckInput(buffer);	
		}
	}
	
	public virtual void CheckInput(bool[,] buffer) {
		if(!inAir) {
			if (buffer[0,UPFORWARD]) {
				StartForwardJump ();
			} else if (buffer[0,UPBACK]) {
				StartBackwardJump ();	
			} else if (buffer[0,Inputs.UP]) {
				StartVerticalJump ();	
			} else if (buffer[0,FORWARD]) {
				if(!animSet.currAnim.Equals(AnimSet.WALKFORWARD))
					animSet.PlayAnim(AnimSet.WALKFORWARD);
				Move (walkSpeed);	
			} else if (buffer[0,BACKWARD]) {
				if(!animSet.currAnim.Equals(AnimSet.BACKPEDAL))
					animSet.PlayAnim(AnimSet.BACKPEDAL);
				Move (-backpedalSpeed);	
			} else if(!animSet.currAnim.Equals(AnimSet.STANDING)) {
				animSet.PlayAnim (AnimSet.STANDING);	
			}
		}
	}
	
	public void Move(float x) {
		Move(x, 0);	
	}
	
	public void Move(float x, float y) {
		if(Mathf.Abs((pos.x + x) - (otherChar.pos.x)) < MainCamera.playerMaxXDist) {
			pos = new Vector3(pos.x + x * direction, pos.y + y, pos.z);
			sprite.clientTransform.position = pos;
			
			if(CheckCollision(pos.x, pos.y)) {
				Displace();
			}
			
			if(pos.x + boundingBox.back > Game.rightMax) {
				ForceMoveAbsolute(Game.rightMax - boundingBox.back,pos.y);	
			} else if(pos.x - boundingBox.back < Game.leftMin) {
				ForceMoveAbsolute(Game.leftMin + boundingBox.back, pos.y);
			}
		} else {
			//Still move y
			pos = new Vector3(pos.x, pos.y + y, pos.z);
			sprite.clientTransform.position = pos;
		}
	}
	
	public void Displace() {
		if(inAir) {
			if(pos.x <= otherChar.pos.x) {
				//Slide other char right
					otherChar.SetRightOfOtherCharacter();
			}
			else {
				//Slide other char left	
				otherChar.SetLeftOfOtherCharacter();
			}
		} else {
			if(pos.x <= otherChar.pos.x) {
				//Slide other char right
				otherChar.SetRightOfOtherCharacter();
			} else {
				//Slide other char left	
				otherChar.SetLeftOfOtherCharacter();
			}
		}
	}
	
	public void SetRightOfOtherCharacter() {
		float rightX = otherChar.pos.x + boundingBox.front + 
			otherChar.boundingBox.front + 0.02f;
		if(rightX + boundingBox.back > Game.rightMax)
			otherChar.SetLeftOfOtherCharacter();
		else
			ForceMoveAbsolute(rightX,pos.y);
	}
	
	public void SetLeftOfOtherCharacter() {
		float leftX = otherChar.pos.x - boundingBox.front -
			otherChar.boundingBox.front - 0.02f;
		if(leftX - boundingBox.back < Game.leftMin)
			otherChar.SetRightOfOtherCharacter();
		else 
			ForceMoveAbsolute(leftX,pos.y);
	}
	
	public void ForceMoveAbsolute(float nx, float ny) {
		pos = new Vector3(nx, ny, pos.z);
		sprite.clientTransform.position = pos;
	}
	
	public virtual bool CheckCollision(float nx, float ny) {
		float left1, left2;
		float right1, right2;
		float top1,top2;
		float bottom1, bottom2;
		
		left1 = nx - boundingBox.back;
		left2 = otherChar.pos.x - otherChar.boundingBox.front;
		right1 = nx + boundingBox.front;
		right2 = otherChar.pos.x + otherChar.boundingBox.back;
		top1 = ny + boundingBox.top;
		top2 = otherChar.pos.y + otherChar.boundingBox.top;
		bottom1 = ny - boundingBox.bottom;
		bottom2 = otherChar.pos.y - otherChar.boundingBox.bottom;
		
		if (bottom1 > top2) 
			return false;
        if (top1 < bottom2) 
			return false;

        if (right1 < left2) 
			return false;
        if (left1 > right2) 
			return false;

        return true;
	}
	
	public void StartVerticalJump ()
	{
		inAir = true;	
		ySpeed = jumpUpSpeed;
		xSpeed = 0;
		animSet.PlayAnim(AnimSet.JUMP);
	}
	
	public void StartForwardJump ()
	{
		inAir = true;	
		ySpeed = jumpUpSpeed;
		xSpeed = jumpForwardVelocity;
		animSet.PlayAnim(AnimSet.FORWARDJUMP);
	}
	
	public void StartBackwardJump ()
	{
		inAir = true;	
		ySpeed = jumpUpSpeed;
		xSpeed = jumpBackwardVelocity;
		animSet.PlayAnim(AnimSet.JUMP);
	}
	
	public virtual void Landed() {
		inAir = false;
		ySpeed = 0;
		xSpeed = 0;	
	}
}
