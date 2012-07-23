using UnityEngine;
using System.Collections;

public class RyuFireballAnimSet : FireballAnimSet{
	
	Sprite sprite;
	SpriteManager sm;
	
	public RyuFireballAnimSet(Sprite sprite, SpriteManager sm) {
		this.sprite = sprite;
		this.sm = sm;
		AddAnimations();
	}
	
	public override void AddAnimations() {
		AddMoveAnimation();
	}
	
	public override void AddMoveAnimation ()
	{
		moveAnimation = new UVAnimation ();
		
		Vector2 startPosUV = sm.PixelCoordToUVCoord (0, 84);
		Vector2 spriteSize = sm.PixelSpaceToUVSpace (88, 84);
		
		moveAnimation.BuildUVAnim (startPosUV, spriteSize, 8, 2, 8, animationFps);
		
		moveAnimation.name = MOVE;
		moveAnimation.loopCycles = -1;
		
		sprite.AddAnimation (moveAnimation);	
	}
	
	public override void AddHitAnimation ()
	{
		
	}
	
}
