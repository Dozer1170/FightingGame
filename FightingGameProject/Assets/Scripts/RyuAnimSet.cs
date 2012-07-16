using UnityEngine;
using System.Collections;

public class RyuAnimSet : AnimSet {
	
	public static string FORWARDDASH = "forwarddash", BACKDASH = "backdash", AIRDASH = "airdash";
	
	UVAnimation forwardDashAnim, backDashAnim, airDashAnim;
	
	public RyuAnimSet(Sprite sprite, SpriteManager sm) {
		this.sprite = sprite;
		this.sm = sm;
		AddAnimations();	
	}
	
	public override void AddAnimations () {
		AddStandingAnimation();
		AddWalkForwardAnimation();
		AddForwardDashAnimation();
		AddBackpedalAnimation();
		AddBackDashAnimation();
		AddAirDashAnimation();
		AddJumpAnimation();
		AddForwardJumpAnimation();
		PlayAnim (standingAnim.name);	
	}
	
	public override void AddStandingAnimation() {
		standingAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 256);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		standingAnim.BuildUVAnim (startPosUV, spriteSize, 9, 1, 9, animationFps);
		
		standingAnim.name = "standing";
		standingAnim.loopCycles = -1;
		
		sprite.AddAnimation (standingAnim);	
	}
	
	public override void AddWalkForwardAnimation() {
		walkForwardAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (256, 512);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		walkForwardAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		walkForwardAnim.name = "walkforward";
		walkForwardAnim.loopCycles = -1;
		
		sprite.AddAnimation (walkForwardAnim);	
	}
	
	public void AddForwardDashAnimation() {
		forwardDashAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1536);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		forwardDashAnim.BuildUVAnim (startPosUV, spriteSize, 6, 1, 6, animationFps);
		
		forwardDashAnim.name = "forwarddash";
		
		sprite.AddAnimation (forwardDashAnim);
	}
	
	public override void AddBackpedalAnimation() {
		backpedalAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 768);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		backpedalAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		backpedalAnim.name = "backpedal";
		backpedalAnim.loopCycles = -1;
		
		sprite.AddAnimation (backpedalAnim);	
	}
	
	public void AddBackDashAnimation() {
		backDashAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1792);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		backDashAnim.BuildUVAnim (startPosUV, spriteSize, 4, 1, 4, animationFps);
		
		backDashAnim.name = "backdash";
		
		sprite.AddAnimation (backDashAnim);
	}
	
	public void AddAirDashAnimation() {
		airDashAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (2560, 256);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		airDashAnim.BuildUVAnim (startPosUV, spriteSize, 4, 1, 4, animationFps);
		
		airDashAnim.name = "airdash";
		
		sprite.AddAnimation (airDashAnim);
	}
	
	public override void AddJumpAnimation() {
		jumpAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1024);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		jumpAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		jumpAnim.name = "jump";
		
		sprite.AddAnimation (jumpAnim);	
	}
	
	public override void AddForwardJumpAnimation() {
		forwardJumpAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1280);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		forwardJumpAnim.BuildUVAnim (startPosUV, spriteSize, 14, 1, 14, animationFps);
		
		forwardJumpAnim.name = "forwardjump";
		
		sprite.AddAnimation (forwardJumpAnim);	
	}
	
}
