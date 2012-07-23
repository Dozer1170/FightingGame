using System;

public class RyuMoveSet : MoveSet
{
	public RyuMoveSet (Character character)
	{
		this.character = character;
		moves = new Move[2]; 
		InitShoryuken();
		InitHadouken();
	}
	
	void InitShoryuken() {
		Move shoryu = new Shoryuken(character);
		moves[0] = shoryu;
	}
	
	void InitHadouken() {
		Move hadouken = new Hadouken(character);
		moves[1] = hadouken;
	}
}


