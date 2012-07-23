using System;
using UnityEngine;

public class Shoryuken : Move
{
	GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
	
	public Shoryuken (Character character)
	{
		this.character = character;
		damage = 10;
		hitStun = 40;
		BoundingBox hitBox = new BoundingBox();
		hitBox.front = 1.0f;
		hitBox.back = .3f;
		hitBox.top = 1.0f;
		hitBox.bottom = -.2f;
		activeFramesStart = 3;
		invincibilityFramesStart = 3;
		invincibilityFramesEnd = 8;
		recoveryFramesStart = 13;
		totalAnimFrames = 30;
		totalFrames = 50;
		animName = RyuAnimSet.SHORYUKEN;
		hitBoxes = new BoundingBox[1];
		hitBoxes[0] = hitBox;
		xMoveSpeed = 0.04f;
		yMoveSpeed = 0.09f;
		InitMoveFrames();
		cube.renderer.material.color = new Color(1f,0f,0f,.5f);
		cube.active = false;
	}
	
	public void InitMoveFrames() {
		movement = new float[2,totalFrames];
		for(int i = 6; i < totalAnimFrames/2; i++)
			movement[0,i] = xMoveSpeed;
		for(int i = 6; i < totalAnimFrames - 5; i++)
			movement[1,i] = yMoveSpeed;
		
		movement[1,totalAnimFrames - 5] = yMoveSpeed - .01f;
		movement[1,totalAnimFrames - 4] = yMoveSpeed - .02f;
		movement[1,totalAnimFrames - 3] = yMoveSpeed - .03f;
		movement[1,totalAnimFrames - 2] = yMoveSpeed - .04f;
		movement[1,totalAnimFrames - 1] = yMoveSpeed - .05f;
	}
	
	public override bool CheckInput (bool[,] buffer)
	{
		return InputChecks.DPP(buffer,character.DOWN, character.DOWNFORWARD, character.FORWARD, Inputs.PUNCH);
	}
	
	public override void Execute ()
	{
		base.Execute ();
		character.xSpeed = 0;
		character.ySpeed = 0;
	}
	
	public override void Update ()
	{	
		base.Update();
		if(currFrame >= recoveryFramesStart) {
			//In recovery
			cube.active = false;
		} else if(currFrame >= activeFramesStart) {
			//Check hitboxes
			cube.active = true;
            cube.transform.position = new Vector3 (hitboxMidX, hitboxMidY, -1);
			cube.transform.localScale = new Vector3 ( (hitBoxes[0].front - hitBoxes[0].back),
				(hitBoxes[0].top - hitBoxes[0].bottom), -1);
			character.inAir = true;
			character.disableFall = true;
		}
		currFrame++;
		
		if(currFrame == totalAnimFrames) {
			character.animSet.PlayAnim(RyuAnimSet.FORWARDJUMP);
			character.disableFall = false;
		}
	}
}


