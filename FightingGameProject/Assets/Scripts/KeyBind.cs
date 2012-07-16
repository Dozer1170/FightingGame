using UnityEngine;
using System.Collections;

public class KeyBind {

	public KeyCode UP;
	public KeyCode DOWN;
	public KeyCode LEFT;
	public KeyCode RIGHT;
	public KeyCode PUNCH;
	public KeyCode KICK;
	
	public KeyBind(KeyCode UP, KeyCode DOWN, KeyCode LEFT, 
		KeyCode RIGHT, KeyCode PUNCH, KeyCode KICK) {
		this.UP = UP;
		this.DOWN = DOWN;
		this.LEFT = LEFT;
		this.RIGHT = RIGHT;
	}
}
