using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
		// Update is called once per frame
	void Update () {
		//Mouse Position in the world. It's important to give it some distance from the camera. 
		//If the screen point is calculated right from the exact position of the camera, then it will
		//just return the exact same position as the camera, which is no good.
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

		//Angle between mouse and this object
		float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

		//Ta daa
		transform.rotation =  Quaternion.Euler (new Vector3(0f,-(angle+90),0f));
	}

	float AngleBetweenPoints(Vector2 a, Vector2 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	}
	