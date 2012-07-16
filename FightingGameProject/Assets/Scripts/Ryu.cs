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
		
	}
	
	public override void CheckInput(bool[,] buffer) {
		if(!busy) {
			base.CheckInput(buffer);
			if(!inAir) {
				if(InputChecks.ForwardDashed(buffer, FORWARD))
					dashInfo.StartForwardDash();
				
				if(InputChecks.BackDashed(buffer, BACKWARD))
					dashInfo.StartBackDash();
			}
		}
	}
}
