using UnityEngine;
using System.Collections;

public class Ryu : Character {
	
	SpriteManager fireballSm;
	DashInfo dashInfo;
	Fireball fireball;
	
	public Ryu(Vector3 pos, Sprite sprite, SpriteManager sm, SpriteManager fireballSm) {
		this.pos = pos;
		this.sprite = sprite;
		this.sm = sm;
		this.fireballSm = fireballSm;
		fireball = new RyuFireball(this.fireballSm);
		sprite.hidden = false;
		fireball.sprite.hidden = false;
		animSet = new RyuAnimSet(sprite, sm);
		dashInfo = new DashInfo(animSet, this);
		moveSet = new RyuMoveSet(this);
	}
	
	public override void Update() {
		base.Update();
		
		if(fireball.active)
			fireball.Update();
		
		if(dashInfo.forwardDashing)
			dashInfo.DoForwardDash();
		else if(dashInfo.backDashing)
			dashInfo.DoBackDash();
		else if(moveSet.hasActiveMove)
			moveSet.UpdateCurrentMove();	
		
	}
	
	public override void CheckInput(bool[,] buffer) {
		if(!busy) {
			base.CheckInput(buffer);
			if(!inAir) {
				if(moveSet.CheckInput(buffer)) {
				} 
				else if(InputChecks.ForwardDashed(buffer, FORWARD))
					dashInfo.StartForwardDash();
				else if(InputChecks.BackDashed(buffer, BACKWARD))
					dashInfo.StartBackDash();
			} else {
				moveSet.CheckInput(buffer);	
			}
		}
	}
	
	public void StartFireball() {
		fireball.StartFireball(new Vector3(pos.x + (boundingBox.front * direction), pos.y, pos.z), direction);
	}
	
	public void StartTatsu() {
		Debug.Log("Tatsu!!!!");	
	}
}
