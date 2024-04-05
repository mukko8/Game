using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    //移動量初期化
    Vector3 moveDirection = Vector3.zero;

    public float gravity;
    public float speed;
    public float speedJump;
    public float rotateSpeed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右に回転
        //if(Input.GetAxis("Mouse X")!=0){
            transform.Rotate(0,Input.GetAxis("Mouse X")*rotateSpeed ,0 );
        //}
        //前後左右に移動
        moveDirection.z = Input.GetAxis("Vertical") * speed;       
        moveDirection.x = Input.GetAxis("Horizontal") * speed;       
        
        if(controller.isGrounded){     
            //ジャンプ
            if(Input.GetButton("Jump")){
                moveDirection.y=speedJump;
            }
        }
        //攻撃
        if(Input.GetButtonDown("Fire1")){
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection*Time.deltaTime);

        if(controller.isGrounded) moveDirection.y = 0;
    }
}
