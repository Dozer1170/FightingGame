using UnityEngine;
using System.Collections;

public class FireballAnimSet {
	
	public static string MOVE = "move", HIT = "hit";
	public UVAnimation moveAnimation, hitAnimation;
	public int animationFps = 20;
	
	public virtual void AddAnimations() {
		
	}
	
	public virtual void AddMoveAnimation() {
		
	}
	
	public virtual void AddHitAnimation() {
		
	}
}
