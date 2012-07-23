using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public SpriteManager ryuSpriteManager;
	public SpriteManager fireballSpriteManager;
	public GameObject spritePrefab;
	
	public static Game instance;
	
	InputBuffer playerOneInputBuffer, playerTwoInputBuffer;
	
	public static float groundHeight = -4.2f;
	public static float leftMin = -6.5f;
	public static float rightMax = 6.5f;
	
	public static Player playerOne, playerTwo;

	// Use this for initialization
	void Start () {
		instance = this;
		Vector3 pos = new Vector3(-2f,-3.7f,-1f);
		GameObject temp = CreateNewSpritePrefab(pos);
		Sprite sprite = ryuSpriteManager.AddSprite(temp,4f,4f,0,0,256,256,false);
		playerOne = new Player(new Ryu(pos, sprite, ryuSpriteManager, fireballSpriteManager));
		playerOneInputBuffer = new InputBuffer(playerOne, 
			new KeyBind(KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D,KeyCode.J,KeyCode.K));
		Vector3 pos2 = new Vector3(2f,-3.7f,-1f);
		GameObject temp2 = CreateNewSpritePrefab(pos2);
		Sprite sprite2 = ryuSpriteManager.AddSprite(temp2,4f,4f,0,0,256,256,false);
		playerTwo = new Player(new Ryu(pos2, sprite2, ryuSpriteManager, fireballSpriteManager));
		playerTwo.FlipDirection();
		playerTwoInputBuffer = new InputBuffer(playerTwo, 
			new KeyBind(KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.LeftArrow,
			KeyCode.RightArrow,KeyCode.Z,KeyCode.X));
		
		MainCamera cam = (MainCamera) GameObject.FindObjectOfType(typeof(MainCamera));
		cam.playerOne = playerOne;
		cam.playerTwo = playerTwo;
		
		playerOne.character.SetOtherChar(playerTwo.character);
		playerTwo.character.SetOtherChar(playerOne.character);
		
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
	
	public GameObject CreateNewSpritePrefab(Vector3 pos) {
		return (GameObject) Instantiate(spritePrefab, pos, Quaternion.identity);
	}
	
	public static Game GetInstance() {
		return instance;	
	}
	
	public static bool CheckCollision(BoundingBox b1, float b1x, float b1y, int b1dir,
			BoundingBox b2, float b2x, float b2y, int b2dir) {
		float left1, left2;
		float right1, right2;
		float top1,top2;
		float bottom1, bottom2;
		
		if(b1dir == 1 && b2dir == -1) {
			//b1 on the left
			left1 = b1x + b1.back;
			left2 = b2x - b2.front;
			right1 = b1x + b1.front;
			right2 = b2x - b2.back;
		} else if(b1dir == -1 && b2dir == 1) {
			//b2 on the left
			left1 = b1x - b1.front;
			left2 = b2x + b2.back;
			right1 = b1x - b1.back;
			right2 = b2x + b2.front;	
		}
		else if(b1dir == 1 && b2dir == 1) {
			//Jump over both same orientation
			left1 = b1x + b1.back;
			left2 = b2x + b2.back;
			right1 = b1x + b1.front;
			right2 = b2x + b2.front;
		} else {
			left1 = b1x - b1.front;
			left2 = b2x - b2.front;
			right1 = b1x - b1.back;
			right2 = b2x - b2.back;
		}
		top1 = b1y + b1.top;
		top2 = b2y + b2.top;
		bottom1 = b1y + b1.bottom;
		bottom2 = b2y + b2.bottom;
		
		if (bottom1 > top2) 
			return false;
        if (top1 < bottom2) 
			return false;

        if (right1 < left2) 
			return false;
        if (left1 > right2) 
			return false;

        return true;
	}
}