using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
    Vector3 look = new Vector3(0,1.0f,0);

	void LateUpdate () {
		transform.position = player.position + (-player.forward * 6.0f) + (player.up * 3.0f);
        look += new Vector3(0,Input.GetAxis("Mouse Y")*0.1f,0);
		transform.LookAt (player.position+Vector3.up*3.0f+look);
	}
}
