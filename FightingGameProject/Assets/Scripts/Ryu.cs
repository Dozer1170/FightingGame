using UnityEngine;
using System.Collections;

public class Ryu : Character {
	
	DashInfo dashInfo;
	
	public Ryu(Vector3 pos, Sprite sprite, SpriteManager sm) {
		this.pos = pos;
		this.sprite = sprite;
		this.sm = sm;
		sprite.hidden = false;
		animSet = new RyuAnimSet(sprite, sm);
		dashInfo = new DashInfo(animSet, this);
	}
	
	public override void Update() {
		base.Update();
		
		if(dashInfo.forwardDashing)
			dashInfo.DoForwardDash();
		else if(dashInfo.backDashing)
			dashInfo.DoBackDash();
		else if(dashInfo.airDashing)
			dashInfo.DoAirDash();
		
	}
	
	public override void CheckInput(bool[,] buffer) {
		if(!busy) {
			base.CheckInput(buffer);
			if(inAir) {
				if(!dashInfo.airDashing) {
					if(InputChecks.ForwardDashed(buffer, FORWARD))
						dashInfo.StartAirDash(1);
					
					if(InputChecks.BackDashed(buffer, BACKWARD))
						dashInfo.StartAirDash(-1);
				}
			} else {
				if(InputChecks.ForwardDashed(buffer, FORWARD))
					dashInfo.StartForwardDash();
				
				if(InputChecks.BackDashed(buffer, BACKWARD))
					dashInfo.StartBackDash();
			}
		}
		
		if(!inAir && Input.GetKeyUp(KeyCode.Space)) {
			FlipDirection();	
		}
	}
	
	public override void Landed ()
	{
		base.Landed ();
		dashInfo.airDashing = false;
	}
}
