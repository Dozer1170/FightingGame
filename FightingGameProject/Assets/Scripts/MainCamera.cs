using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	Vector3 focalPoint;
	public float minY;
	public float minX;
	public float maxX;
	public float maxY;
	public static float playerMaxXDist = 8;
	
	public Player playerOne, playerTwo;
	
	// Use this for initialization
	void Start () {
		focalPoint = GameObject.Find("Background").transform.position;
		focalPoint = new Vector3(focalPoint.x, minY, -8);
	}
	
	// Update is called once per frame
	void Update () {
		MoveCameraTo(FindMidX(),FindMidY());
	}
	
	void MoveCameraTo(float x, float y) {
		if(y < minY)
			y = minY;
		
		if(y > maxY)
			y = maxY;
		
		if(x < minX)
			x = minX;
		
		if(x > maxX)
			x = maxX;
		
		focalPoint = new Vector3(x,
			y, focalPoint.z);
		transform.position = focalPoint;
	}
	
	float FindMidX() {
		float dist;
		if(playerOne.character.pos.x < playerTwo.character.pos.x) {
			dist = playerTwo.character.pos.x - playerOne.character.pos.x;
			return playerOne.character.pos.x + dist/2;
		}
		else {
			dist = playerOne.character.pos.x - playerTwo.character.pos.x;	
			return playerTwo.character.pos.x + dist/2;
		}
	}
	
	float FindMidY() {
		float dist = playerOne.character.pos.y - playerTwo.character.pos.y;
		if(playerOne.character.pos.y < playerTwo.character.pos.y) {
			dist = playerTwo.character.pos.y - playerOne.character.pos.y;
			return playerOne.character.pos.y + dist/2;
		}
		else {
			dist = playerOne.character.pos.y - playerTwo.character.pos.y;	
			return playerTwo.character.pos.y + dist/2;
		}
	}
}
