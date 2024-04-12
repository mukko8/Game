using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	float cameraPosY = 3.0f;
	float cameraPosZ = 6.0f;
	//向きの変化量を保存する	
  Vector3 look = Vector3.zero;

	void Start(){
		transform.forward=player.forward;
	}

	void LateUpdate () {
		//カメラの位置＝playerの上後方
		transform.position = player.position + (-player.forward * cameraPosZ) + (player.up * cameraPosY);
    //左右はplayerの旋回と連動するので　上下方向のみ  
		look += new Vector3 (0,Input.GetAxis("Mouse Y")*0.02f,0);
		
		if(look.y <= 2 && look.y >= -0.5){
    	//左右はplayerの旋回と連動するので　上下方向のみ  
			look += new Vector3 (0,Input.GetAxis("Mouse Y")*0.02f,0);
		}
		transform.forward=player.forward+look;
	}
}
