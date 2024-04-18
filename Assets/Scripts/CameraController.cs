using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	PlayerController pc;
	float cameraPosY = 3.0f;
	float cameraPosZ = 6.0f;
	//向きの変化量を保存する	
  Vector3 look = Vector3.zero;

	void Start(){
		transform.forward=player.transform.forward;
	}
	void Update(){

	}

	void LateUpdate () {
		if(player){
		//カメラの位置＝playerの上後方
		transform.position = player.transform.position + (-player.transform.forward * cameraPosZ) + (player.transform.up * cameraPosY);
    //左右はplayerの旋回と連動するので　上下方向のみ  
		look += new Vector3 (0,Input.GetAxis("Mouse Y")*0.02f,0);
		
		if(look.y <= 2 && look.y >= -0.5){
    	//左右はplayerの旋回と連動するので　上下方向のみ  
			look += new Vector3 (0,Input.GetAxis("Mouse Y")*0.02f,0);
		}
		transform.forward=player.transform.forward+look;
		}
	}
}
