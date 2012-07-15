using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	Vector3 focalPoint;
	public float minY;
	
	// Use this for initialization
	void Start () {
		focalPoint = GameObject.Find("Background").transform.position;
		focalPoint = new Vector3(focalPoint.x, minY, -8);
	}
	
	// Update is called once per frame
	void Update () {
		MoveCamera(0,0);
	}
	
	void MoveCamera(float x, float y) {
		if(focalPoint.y + y > minY)
			y = 0;
		focalPoint = new Vector3(focalPoint.x + x,
			focalPoint.y + y, focalPoint.z);
		transform.position = focalPoint;
	}
}
