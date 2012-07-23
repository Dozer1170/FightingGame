using UnityEngine;
using System.Collections;

public class RyuAnimSet : AnimSet {
	
	public static string FORWARDDASH = "forwarddash", BACKDASH = "backdash", AIRDASH = "airdash";
	public static string HADOUKEN = "hadouken", SHORYUKEN = "shoryuken";
	
	UVAnimation forwardDashAnim, backDashAnim, airDashAnim, shoryukenAnim, hadoukenAnim,
		normalHitAnim;
	
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
		AddShoryukenAnimation();
		AddHadoukenAnimation();
		AddNormalHitAnimation();
		PlayAnim (standingAnim.name);	
	}
	
	public override void AddStandingAnimation() {
		standingAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 256);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		standingAnim.BuildUVAnim (startPosUV, spriteSize, 9, 1, 9, animationFps);
		
		standingAnim.name = STANDING;
		standingAnim.loopCycles = -1;
		
		sprite.AddAnimation (standingAnim);	
	}
	
	public override void AddWalkForwardAnimation() {
		walkForwardAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (256, 512);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		walkForwardAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		walkForwardAnim.name = WALKFORWARD;
		walkForwardAnim.loopCycles = -1;
		
		sprite.AddAnimation (walkForwardAnim);	
	}
	
	public void AddForwardDashAnimation() {
		forwardDashAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1536);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		forwardDashAnim.BuildUVAnim (startPosUV, spriteSize, 6, 1, 6, 15);
		
		forwardDashAnim.name = FORWARDDASH;
		
		sprite.AddAnimation (forwardDashAnim);
	}
	
	public override void AddBackpedalAnimation() {
		backpedalAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 768);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		backpedalAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		backpedalAnim.name = BACKPEDAL;
		backpedalAnim.loopCycles = -1;
		
		sprite.AddAnimation (backpedalAnim);	
	}
	
	public void AddBackDashAnimation() {
		backDashAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1792);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		backDashAnim.BuildUVAnim (startPosUV, spriteSize, 4, 1, 4, animationFps);
		
		backDashAnim.name = BACKDASH;
		
		sprite.AddAnimation (backDashAnim);
	}
	
	public void AddAirDashAnimation() {
		airDashAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (2560, 256);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		airDashAnim.BuildUVAnim (startPosUV, spriteSize, 4, 1, 4, animationFps);
		
		airDashAnim.name = AIRDASH;
		
		sprite.AddAnimation (airDashAnim);
	}
	
	public override void AddJumpAnimation() {
		jumpAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1024);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		jumpAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		jumpAnim.name = JUMP;
		
		sprite.AddAnimation (jumpAnim);	
	}
	
	public override void AddForwardJumpAnimation() {
		forwardJumpAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 1280);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		forwardJumpAnim.BuildUVAnim (startPosUV, spriteSize, 14, 1, 14, animationFps);
		
		forwardJumpAnim.name = FORWARDJUMP;
		
		sprite.AddAnimation (forwardJumpAnim);	
	}
	
	public void AddShoryukenAnimation() {
		shoryukenAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (1024, 1792);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		shoryukenAnim.BuildUVAnim (startPosUV, spriteSize, 5, 1, 5, 10);
		
		shoryukenAnim.name = SHORYUKEN;
		
		sprite.AddAnimation (shoryukenAnim);	
	}
	
	public void AddHadoukenAnimation() {
		hadoukenAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 2048);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		hadoukenAnim.BuildUVAnim (startPosUV, spriteSize, 11, 1, 11, animationFps);
		
		hadoukenAnim.name = HADOUKEN;
		
		sprite.AddAnimation (hadoukenAnim);	
	}
	
	public void AddNormalHitAnimation() {
		normalHitAnim = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (2816, 768);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (256, 256);
		
		normalHitAnim.BuildUVAnim (startPosUV, spriteSize, 5, 1, 5, animationFps);
		
		normalHitAnim.name = NORMALHIT;
		
		sprite.AddAnimation (normalHitAnim);	
	}
}
