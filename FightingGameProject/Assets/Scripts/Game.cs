using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public SpriteManager spriteManager;
	public GameObject playerPrefab;
	
	InputBuffer inputBuffer;
	
	public static float groundHeight = -4.7f;
	
	Player playerOne, playerTwo;

	// Use this for initialization
	void Start () {
		Vector3 pos = new Vector3(-2f,-3.7f,-1f);
		GameObject temp = (GameObject) Instantiate(playerPrefab, pos, Quaternion.identity);
		Sprite sprite = spriteManager.AddSprite(temp,4f,4f,0,0,256,256,false);
		playerOne = new Player(new Ryu(pos, sprite, spriteManager));
		inputBuffer = new InputBuffer(playerOne);
		Vector3 pos2 = new Vector3(2f,-3.7f,-1f);
		GameObject temp2 = (GameObject) Instantiate(playerPrefab, pos2, Quaternion.identity);
		Sprite sprite2 = spriteManager.AddSprite(temp2,4f,4f,0,0,256,256,false);
		playerTwo = new Player(new Ryu(pos2, sprite2, spriteManager));
		playerTwo.FlipDirection();
		Invoke("UpdateGame", 0.0166f);
	}
	
	// Update is called once per frame
	void UpdateGame () {
		inputBuffer.Update();
		playerOne.Update();
		playerTwo.Update();
		Invoke("UpdateGame", 0.0166f);
	}
}