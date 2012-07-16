using UnityEngine;
using System.Collections;

public class InputBuffer {
	
	public static int bufferSize = 15;
	private Player player;
	bool[,] buffer;
	public KeyBind keybind;

	public InputBuffer(Player player, KeyBind keybind) {
		this.player = player;
		this.keybind = keybind;
		buffer = new bool[bufferSize,Inputs.NUMINPUTS];
	}
	
	// Update is called once per frame
	public void Update () {
		
		buffer[0,Inputs.UP] = Input.GetKey(keybind.UP);
		buffer[0,Inputs.DOWN] = Input.GetKey(keybind.DOWN);
		buffer[0,Inputs.LEFT] = Input.GetKey(keybind.LEFT);
		buffer[0,Inputs.RIGHT] = Input.GetKey(keybind.RIGHT);
		buffer[0,Inputs.UPRIGHT] = buffer[0,Inputs.UP] & buffer[0,Inputs.RIGHT];
		buffer[0,Inputs.UPLEFT] = buffer[0,Inputs.UP] & buffer[0,Inputs.LEFT];
		buffer[0,Inputs.DOWNRIGHT] = buffer[0,Inputs.DOWN] & buffer[0,Inputs.RIGHT];
		buffer[0,Inputs.DOWNLEFT] = buffer[0,Inputs.DOWN] & buffer[0,Inputs.LEFT];
		buffer[0,Inputs.PUNCH] = Input.GetKey(keybind.KICK);
		buffer[0,Inputs.KICK] = Input.GetKey(keybind.KICK);
		
		if(buffer[0,Inputs.UPRIGHT]) {
			buffer[0,Inputs.UP] = false;
			buffer[0,Inputs.RIGHT] = false;
		}
		if(buffer[0,Inputs.UPLEFT]) {
			buffer[0,Inputs.UP] = false;
			buffer[0,Inputs.LEFT] = false;
		}
		if(buffer[0,Inputs.DOWNRIGHT]) {
			buffer[0,Inputs.DOWN] = false;
			buffer[0,Inputs.RIGHT] = false;
		}
		if(buffer[0,Inputs.DOWNLEFT]) {
			buffer[0,Inputs.DOWN] = false;
			buffer[0,Inputs.LEFT] = false;
		}
		
		player.TryCheckInput(buffer);
		
		MoveBufferFramesUp();
	}
	
	void MoveBufferFramesUp() {
		for(int i = bufferSize - 1; i > 0; i--) {
			buffer[i,Inputs.UP] = buffer[i-1,Inputs.UP];
			buffer[i,Inputs.DOWN] = buffer[i-1,Inputs.DOWN];
			buffer[i,Inputs.LEFT] = buffer[i-1,Inputs.LEFT];
			buffer[i,Inputs.RIGHT] = buffer[i-1,Inputs.RIGHT];
			buffer[i,Inputs.PUNCH] = buffer[i-1,Inputs.PUNCH];
			buffer[i,Inputs.KICK] = buffer[i-1,Inputs.KICK];
		}
	}
}
