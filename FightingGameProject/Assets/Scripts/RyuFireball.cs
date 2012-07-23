using UnityEngine;
using System.Collections;

public class RyuFireball : Fireball {

	public RyuFireball(SpriteManager sm) {
		this.sm = sm;
		GameObject temp = Game.GetInstance().CreateNewSpritePrefab(new Vector3(0,0,1));
		this.sprite = sm.AddSprite(temp,1f,1f,0,0,84,88,false);
		this.fireballAnimSet = new RyuFireballAnimSet(sprite, sm);
	}
	
}
