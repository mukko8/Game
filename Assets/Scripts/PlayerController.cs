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
    public int playerHp;
    public BulletLuncher bl; 
    int weponIndex;
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        weponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = speed;
                 
        if(controller.isGrounded){     
            //ジャンプ
            if(Input.GetButton("Jump")){
                moveDirection.y=speedJump;
            }
            //ダッシュ
            if(Input.GetKey(KeyCode.LeftShift)){
                currentSpeed = speed * 3.0f;
            }else{
                currentSpeed = speed;
            }
        } 
        //左右に回転
        if(Input.GetAxis("Mouse X")!=0){
            transform.Rotate(0,Input.GetAxis("Mouse X")*rotateSpeed ,0 );
        }
        //前後左右に移動
        moveDirection.z = Input.GetAxis("Vertical") * currentSpeed;       
        moveDirection.x = Input.GetAxis("Horizontal") * currentSpeed;
        
        //持ち替え
        if(Input.GetMouseButtonDown(1)){
            weponIndex ++;
        }
        //攻撃
        if(Input.GetMouseButtonDown(0)){
           bl.BulletShot(); 
        }
        //被弾
        if(playerHp <=0){
            Destroy(gameObject);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection*Time.deltaTime);

        if(controller.isGrounded) moveDirection.y = 0;
    }
}
