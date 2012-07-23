using UnityEngine;
using System.Collections;

public class Fireball {
	
	public SpriteManager sm;
	public Sprite sprite;
	public FireballAnimSet fireballAnimSet;
	public bool active;
	Vector3 pos;
	int direction;
	float horizontalSpeed = 0.10f;
	float verticalSpeed = 0.00f;
	
	public Fireball() {
		
	}
	
	public Fireball(SpriteManager fireballSm) {
		this.sm = fireballSm;
	}
	
	public void StartFireball(Vector3 pos, int direction) {
		this.pos = pos;
		this.direction = direction;
		active = true;
		sprite.PlayAnim(FireballAnimSet.MOVE);
	}
	
	public void Update() {
		if(active)
			Move (horizontalSpeed, 0);
	}
	
	void Move(float x, float y) {
		pos = new Vector3(pos.x + x * direction, pos.y + y, pos.z);
		sprite.clientTransform.position = pos;
	}
}
