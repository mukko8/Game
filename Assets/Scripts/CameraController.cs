using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	void Start(){
		transform.forward=player.forward;
	}
	//向きの変化量を保存する	
  Vector3 look = Vector3.zero;

	void LateUpdate () {
		//カメラの位置＝playerの上後方
		transform.position = player.position + (-player.forward * 6.0f) + (player.up * 3.0f);
    //左右はplayerの旋回と連動するので　上下方向のみ  
		look.y += Input.GetAxis("Mouse Y")*0.02f;
		//playerの少し上（＋上下方向look分）に向く
		if(look.y <= 2 && look.y >= -0.5){
			transform.forward=player.forward+look;
		}
	}
}
