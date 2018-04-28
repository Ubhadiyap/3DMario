using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	
	public Transform lookAt;

	//the distance between player and camera
	public float distance = 10.0f;

	private float currentX = 0.0f;
	private float currentY = 45.0f;
	//private float sensitivityX = 4.0f;
	//private float sensitivityY = 1.0f;

	private void LateUpdate()
	{
		//added by adel
		transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector3 dir = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		transform.position = lookAt.position + rotation * dir;
        transform.rotation = lookAt.rotation;
        transform.LookAt(lookAt.position);
	}
}
