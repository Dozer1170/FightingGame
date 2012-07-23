using UnityEngine;
using System.Collections;

public class BoundingBox {
	
	public float front,back,top,bottom;
	
	public BoundingBox() {
		front = 0.4f;
		back = -0.4f;
		top = 0.4f;
		bottom = -0.4f;
	}
	
	public BoundingBox(float front, float back, float top, float bottom) {
		this.front = front;
		this.back = back;
		this.top = top;
		this.bottom = bottom;
	}
}
