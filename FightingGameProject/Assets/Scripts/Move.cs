using System;

public class Move
{
	public Character character;
	public string animName;
	public int currFrame;
	public int activeFramesStart;
	public int recoveryFramesStart;
	public int invincibilityFramesStart;
	public int invincibilityFramesEnd;
	public int totalAnimFrames;
	public int totalFrames;
	public float[,] movement;
	public float xMoveSpeed;
	public float yMoveSpeed;
	public int damage;
	public BoundingBox[] hitBoxes;
	public float hitboxMidX, hitboxMidY;
	public int hitStun;
	public bool hit;
	
	public Move() {
		
	}
	
	public Move (Character character)
	{
		this.character = character;
	}
	
	public virtual bool CheckInput(bool[,] buffer) {
		return false;
	}
	
	public virtual void Execute() {
		character.animSet.PlayAnim(animName);
		currFrame = 0;
		hit = false;
	}
	
	public virtual void Update() {
		if(movement != null && currFrame < totalFrames)
			character.Move(movement[0,currFrame],movement[1,currFrame]);
		
		if(currFrame >= activeFramesStart && currFrame < recoveryFramesStart && CheckHit()) {
			character.otherChar.TakeHit(damage);
			character.otherChar.currRecovery = hitStun;
		}
	}
	
	public virtual bool Done() {
		return currFrame > totalFrames;	
	}
	
	public bool CheckHit() {
		hitboxMidX = character.pos.x + (hitBoxes[0].front + hitBoxes[0].back)/2 * character.direction;
		hitboxMidY = character.pos.y + (hitBoxes[0].top + hitBoxes[0].bottom)/2;
		if(!hit) {
			if(Game.CheckCollision(hitBoxes[0], hitboxMidX, hitboxMidY, character.direction,
					character.otherChar.boundingBox, character.otherChar.pos.x, character.otherChar.pos.y,
					character.otherChar.direction)) {
				hit = true;
				return true;
			}
		}
		return false;
	}
}