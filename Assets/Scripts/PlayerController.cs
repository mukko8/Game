using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    //移動量初期化
    Vector3 moveDirection = Vector3.zero;

    [SerializeField] float gravity;

    [SerializeField] float speed;

    [SerializeField] float speedJump;

    [SerializeField] float rotateSpeed;

    [SerializeField] float playerHp;
    public float PlayerHp{get {return playerHp;}}

    private float currentSpeed;
    //[SerializeField] Transform cam;
    public Image img;
    

    public BulletLuncher bl; 
    int weponIndex;
    bool rug = true;
    float rugTime;
    float nowHp => playerHp;//getterのこと
    float preHp;
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        weponIndex = 0;
        rugTime = 0.5f;

        img.color = Color.clear;
        preHp = nowHp;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = speed;
                 
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
        
        //右クリックで武器の持ち替え
        if(Input.GetMouseButtonDown(1)){
            weponIndex ++;
            weponIndex %=3;

        }
        //左クリックで攻撃
        if(Input.GetMouseButton(0) && rug==true){
          bl.BulletShot(weponIndex); 
          //発射間隔設定
          rug = false;
          switch(weponIndex){
            case 0:
                rugTime = 0.35f;
            break;
            case 1:
                rugTime = 0.9f;
            break;
            case 2:
                rugTime = 0.15f;
            break;
            }
            Invoke("Timer",rugTime);
        }

        //被弾時画面を赤くする
        if(nowHp < preHp){
            img.color = new Color(0.5f, 0f, 0f, 0.7f);
            preHp = nowHp;
            //cam.DOComplete();
            //gameObject.transform.DOShakePosition(0.3f,1);
            //cam.DOShakeRotation(0.3f, rotationStrength);
        }
        img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime*1.5f);
        if(playerHp <=0){
            Destroy(gameObject);
            
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection*Time.deltaTime);

        if(controller.isGrounded) moveDirection.y = 0;

        
    }
    void Timer(){
        rug =true;
    }

    public void Damege(float value)
    {
        playerHp -= value;
    }
}
