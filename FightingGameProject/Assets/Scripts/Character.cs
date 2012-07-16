using UnityEngine;
using System.Collections;

public class Character {
	
	public Vector3 pos;
	public bool inAir = false;
	public bool busy = false;
	public bool disableFall = false;
	protected float distToBotSprite = 1.0f;
	protected float distToSidesSprites = 1.0f;
	protected SpriteManager sm;
	protected Sprite sprite;
	protected AnimSet animSet;
	protected float walkSpeed = 0.03f;
	protected float backpedalSpeed = 0.02f;
	protected float jumpUpSpeed = 0.20f;
	protected float jumpDec = 0.005f;
	protected float jumpForwardVelocity = 0.04f;
	protected float jumpBackwardVelocity = -0.03f;
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
				if (pos.y - distToBotSprite + ySpeed > Game.groundHeight) {
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
		if(pos.x + x + distToSidesSprites > Game.rightMax || 
			pos.x + x - distToSidesSprites < Game.leftMin) {
			x = 0;
		}
			
		pos = new Vector3(pos.x + x * direction, pos.y + y, pos.z);
		sprite.clientTransform.position = pos;
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
