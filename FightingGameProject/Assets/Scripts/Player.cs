using UnityEngine;
using System.Collections;
using System;

public class Player
{
	public Character character;
	
	public Player (Character character)
	{
		this.character = character;
	}
	
	public void Update ()
	{
		character.Update();
	}
	
	public void TryCheckInput(bool[,] buffer) {
		character.TryCheckInput(buffer);
	}
	
	public void FlipDirection() {
		character.FlipDirection();	
	}
}
