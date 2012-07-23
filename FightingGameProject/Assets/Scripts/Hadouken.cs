using System;
using UnityEngine;

public class Hadouken : Move
{
	public Hadouken (Character character)
	{
		this.character = character;
		activeFramesStart = 12;
		invincibilityFramesStart = 3;
		invincibilityFramesEnd = 8;
		recoveryFramesStart = 12;
		totalFrames = 32;
		animName = RyuAnimSet.HADOUKEN;
		xMoveSpeed = 0.04f;
		yMoveSpeed = 0.09f;
	}
	
	public override bool CheckInput (bool[,] buffer)
	{
		return InputChecks.QCFP(buffer,character.DOWN, character.DOWNFORWARD, character.FORWARD, Inputs.PUNCH);
	}
	
	public override void Execute ()
	{
		base.Execute ();
		if(character is Ryu) {
			((Ryu) character).StartFireball();	
		}
	}
	
	public override void Update ()
	{
		currFrame++;
	}
}

