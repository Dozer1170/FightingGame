using UnityEngine;
using System.Collections;

public class MoveSet {
	
	public Character character;
	public Move[] moves;
	public bool hasActiveMove;
	public Move activeMove;
	
	public MoveSet() {
	}
	
	public bool CheckInput(bool[,] buffer) {
		for(int i = 0; i < moves.Length; i++) {
			if(moves[i].CheckInput(buffer)) {
				moves[i].Execute();	
				activeMove = moves[i];
				hasActiveMove = true;
				character.busy = true;
				return true;
			}
		}
		return false;
	}
	
	public void UpdateCurrentMove() {
		activeMove.Update();
		if(activeMove.Done()) {
			hasActiveMove = false;
			character.busy = false;
		}
	}
}
