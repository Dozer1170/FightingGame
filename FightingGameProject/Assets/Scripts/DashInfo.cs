using UnityEngine;
using System.Collections;

public class DashInfo {

	int dashRecovery = 5;
	int forwardDashDuration = 15;
	int backDashDuration = 12;
	int backDashMovementDuration = 10;
	int airDashSpeedDuration = 20;
	int airDashDir;
	int dashProgress = 0;
	float dashSpeed = 0.06f;
	float airDashSpeed = 0.08f;
	public bool forwardDashing = false;
	public bool backDashing = false;
	public bool airDashing = false;
	public bool airDashMoveDone = false;
	
	AnimSet animSet;
	Character character;
	
	public DashInfo(AnimSet anims, Character character) {
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
	
	public void StartForwardDash() {
		character.busy = true;
		forwardDashing = true;
		dashProgress = 0;
		animSet.PlayAnim(RyuAnimSet.FORWARDDASH);
		DoForwardDash();
	}
	
	public void DoForwardDash() {
		if(dashProgress < forwardDashDuration) {
			character.Move(dashSpeed);
			dashProgress++;
		} else {
			character.busy = false;
			forwardDashing = false;
			character.currRecovery = dashRecovery;
		}
	}
	
	public void StartBackDash() {
		character.busy = true;
		backDashing = true;
		dashProgress = 0;
		animSet.PlayAnim(RyuAnimSet.BACKDASH);
		DoBackDash();
	}
	
	public void DoBackDash() {
		if(dashProgress < backDashDuration) {
			if(dashProgress < backDashMovementDuration)
				character.Move(-dashSpeed);
			
			dashProgress++;
		} else {
			character.busy = false;
			backDashing = false;
			character.currRecovery = dashRecovery;
			animSet.PlayAnim(AnimSet.STANDING);
		}
	}
}
