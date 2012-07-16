using UnityEngine;
using System.Collections;

public class DashInfo {

	public int dashRecovery = 5;
	public int forwardDashDuration = 15;
	public int backDashDuration = 12;
	public int backDashMovementDuration = 10;
	public int dashProgress = 0;
	public float dashSpeed = 0.06f;
	public float airDashSpeed = 0.08f;
	public bool forwardDashing = false;
	public bool backDashing = false;
	
	public AnimSet animSet;
	public Character character;
	
	public DashInfo() {
		
	}
	
	public DashInfo(AnimSet anims, Character character) {
		this.animSet = anims;
		this.character = character;
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
