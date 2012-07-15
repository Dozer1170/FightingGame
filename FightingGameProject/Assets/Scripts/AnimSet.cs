using UnityEngine;
using System.Collections;

public class AnimSet {
	
	public static string STANDING = "standing";
	public static string WALKFORWARD = "walkforward";
	public static string BACKPEDAL = "backpedal";
	public static string JUMP = "jump";
	public static string FORWARDJUMP = "forwardjump";

	public string currAnim;
	protected UVAnimation standingAnim;
	protected UVAnimation walkForwardAnim;
	protected UVAnimation backpedalAnim;
	protected UVAnimation jumpAnim;
	protected UVAnimation forwardJumpAnim;
	protected int animationFps = 15;
	
	protected Sprite sprite;
	protected SpriteManager sm;
	
	public AnimSet() {
		
	}
	
	public AnimSet(Sprite sprite, SpriteManager sm) {
		this.sprite = sprite;
		this.sm = sm;
	}
	
	public virtual void AddAnimations ()
	{
		
	}
	
	public virtual void AddStandingAnimation() {
	
	}
	
	public virtual void AddWalkForwardAnimation() {
		
	}
	
	public virtual void AddBackpedalAnimation() {
		
	}
	
	public virtual void AddJumpAnimation() {

	}
	
	public virtual void AddForwardJumpAnimation() {
		
	}
	
	public void PlayAnim (string name) {
		sprite.PlayAnim (name);	
		currAnim = name;
	}
	
}
