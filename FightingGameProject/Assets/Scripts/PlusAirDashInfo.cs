using UnityEngine;
using System.Collections;

public class PlusAirDashInfo : DashInfo {
	
	public int airDashSpeedDuration = 20;
	public int airDashDir;
	public bool airDashing = false;
	public bool airDashMoveDone = false;
	
	public PlusAirDashInfo(AnimSet anims, Character character) {
		this.animSet = anims;
		this.character = character;
	}
	
	public void StartAirDash(int dir) {
		dashProgress = 0;
		airDashing = true;
		airDashMoveDone = false;
		airDashDir = dir;
		character.disableFall = true;
		character.ySpeed = 0;
		character.xSpeed = airDashDir * airDashSpeed;
		animSet.PlayAnim(RyuAnimSet.AIRDASH);
	}
	
	public void DoAirDash() {
		if(!airDashMoveDone) {
			if(dashProgress < airDashSpeedDuration) {
				dashProgress++;
			} else {
				airDashMoveDone = true;
				character.disableFall = false;
				character.currRecovery = dashRecovery;
			}
		}
	}
	
}
