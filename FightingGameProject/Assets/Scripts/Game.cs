using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public SpriteManager spriteManager;
	public GameObject playerPrefab;
	
	InputBuffer playerOneInputBuffer, playerTwoInputBuffer;
	
	public static float groundHeight = -4.2f;
	public static float leftMin = -6.5f;
	public static float rightMax = 6.5f;
	
	public static Player playerOne, playerTwo;

	// Use this for initialization
	void Start () {
		Vector3 pos = new Vector3(-2f,-3.7f,-1f);
		GameObject temp = (GameObject) Instantiate(playerPrefab, pos, Quaternion.identity);
		Sprite sprite = spriteManager.AddSprite(temp,4f,4f,0,0,256,256,false);
		playerOne = new Player(new Ryu(pos, sprite, spriteManager));
		playerOneInputBuffer = new InputBuffer(playerOne, 
			new KeyBind(KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D,KeyCode.J,KeyCode.K));
		Vector3 pos2 = new Vector3(2f,-3.7f,-1f);
		GameObject temp2 = (GameObject) Instantiate(playerPrefab, pos2, Quaternion.identity);
		Sprite sprite2 = spriteManager.AddSprite(temp2,4f,4f,0,0,256,256,false);
		playerTwo = new Player(new Ryu(pos2, sprite2, spriteManager));
		playerTwo.FlipDirection();
		playerTwoInputBuffer = new InputBuffer(playerTwo, 
			new KeyBind(KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.LeftArrow,
			KeyCode.RightArrow,KeyCode.Z,KeyCode.X));
		
		playerOne.character.SetOtherChar(playerTwo.character);
		playerTwo.character.SetOtherChar(playerOne.character);
		
		
		MainCamera cam = (MainCamera) GameObject.FindObjectOfType(typeof(MainCamera));
		cam.playerOne = playerOne;
		cam.playerTwo = playerTwo;
		
		Invoke("UpdateGame", 0.0166f);
	}
	
	// Update is called once per frame
	void UpdateGame () {
		playerOneInputBuffer.Update();
		playerTwoInputBuffer.Update();
		playerOne.Update();
		playerTwo.Update();
		
		CheckDirections();
		
		Invoke("UpdateGame", 0.0166f);
	}
	
	void CheckDirections() {
		if(playerOne.character.pos.x < playerTwo.character.pos.x){
			if(playerOne.character.direction != 1) {
				if(!playerOne.character.inAir)	
					playerOne.character.FlipDirection();
			}
			if(playerTwo.character.direction != -1) {
				if(!playerTwo.character.inAir)	
					playerTwo.character.FlipDirection();
			}
		} else if(playerOne.character.pos.x > playerTwo.character.pos.x){
			if(playerOne.character.direction != -1) {
				if(!playerOne.character.inAir)	
					playerOne.character.FlipDirection();
			}
			if(playerTwo.character.direction != 1) {
				if(!playerTwo.character.inAir)	
					playerTwo.character.FlipDirection();
			}
		}		
	}
}