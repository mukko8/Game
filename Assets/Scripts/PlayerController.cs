using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float PlayerHp { get { return playerHp; } }
    [SerializeField] float exp;
    public float PlayerExp { get { return exp; } }

    [SerializeField] AudioSourceController asc;
    [SerializeField] GameObject Defeat;
    [SerializeField] GameObject OrbEffect;
    

    private float currentSpeed;


    public BulletLuncher bl;
    int weponIndex;
    bool rug = true;
    bool isAlive ;
    float rugTime;
    public Image DamageFlash;

    public void Damege(float value)
    {
        playerHp -= value;
        //ダメージエフェクト　画面を赤くする
        DamageFlash.color = new Color(0.7f, 0, 0, 0.7f);
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        weponIndex = 0;
        rugTime = 0.5f;
        isAlive = true;
        DamageFlash.color = Color.clear;
        exp =0;
        //playerHp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = speed;
        if(isAlive)
        if (controller.isGrounded)
        {
            //ジャンプ
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = speedJump;
            }
            //ダッシュ
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = speed * 3.0f;
            }
            else
            {
                currentSpeed = speed;
            }
        }
        //左右に回転
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
        }
        //前後左右に移動
        moveDirection.z = Input.GetAxis("Vertical") * currentSpeed;
        moveDirection.x = Input.GetAxis("Horizontal") * currentSpeed;

        //持ち替え
        if (Input.GetMouseButtonDown(1))
        {
            weponIndex++;
            weponIndex %= 3;
            asc.PlayAudio(weponIndex+3);

        }
        //攻撃
        if (Input.GetMouseButton(0) && rug == true)
        {
            bl.BulletShot(weponIndex);
            //発射間隔設定
            rug = false;
            switch (weponIndex)
            {
                case 0:
                    rugTime = 0.35f;
                    asc.PlayAudio(0);
                    break;
                case 1:
                    rugTime = 0.9f;
                    asc.PlayAudio(1);
                    break;
                case 2:
                    rugTime = 0.15f;
                    asc.PlayAudio(2);
                    break;
            }
            Invoke("Timer", rugTime);
        }

        //ダメージエフェクトを徐々に消す
        DamageFlash.color = Color.Lerp(DamageFlash.color, Color.clear, Time.deltaTime);
        
        //死亡時  
        if (playerHp <= 0)
        {
            Instantiate(Defeat, gameObject.transform.position, Quaternion.identity);
            Destroy(Defeat,0.5f);
            gameObject.SetActive (!gameObject.activeSelf);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;


    }
    void Timer()
    {
        rug = true;
    }
    //オーブ取得
    private void OnControllerColliderHit(ControllerColliderHit other) {
        if(other.gameObject.CompareTag("Orb")){
            exp += 0.4f;
            Destroy(other.gameObject);
            Instantiate(OrbEffect, gameObject.transform.position, Quaternion.identity);
            if(exp>=1.0f){
                //レベルアップ
                exp -=1.0f;
            }
            Debug.Log(exp);
        }
    }
    

}
