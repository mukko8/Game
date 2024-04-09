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
    public GameObject HitEffect;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed;
        //左右に回転
        if(Input.GetAxis("Mouse X")!=0){
            transform.Rotate(0,Input.GetAxis("Mouse X")*rotateSpeed ,0 );
        }
        //ダッシュ
        if(Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = speed * 3.0f;
        }else{
            currentSpeed = speed;
        }
        
        //前後左右に移動
        moveDirection.z = Input.GetAxis("Vertical") * currentSpeed;       
        moveDirection.x = Input.GetAxis("Horizontal") * currentSpeed;       
        
        if(controller.isGrounded){     
            //ジャンプ
            if(Input.GetButton("Jump")){
                moveDirection.y=speedJump;
            }
        }
        //攻撃
        if(Input.GetButtonDown("Fire1")){
            //画面の中心に向かってraycastを飛ばす
            /*Ray ray = Camera.main.ScreenPointToRay(
                Camera.main.ViewportToScreenPoint(Camera.main.rect.center)
            );

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, 100f)) {
                Instantiate(HitEffect, hit.point, Quaternion.identity);
                //Destroy(hit.collider.gameObject);
                Destroy(HitEffect,0.5f);
            }
            */
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection*Time.deltaTime);

        if(controller.isGrounded) moveDirection.y = 0;
    }
}
