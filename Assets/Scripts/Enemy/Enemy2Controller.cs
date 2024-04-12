using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Transform player;
    public GameObject canonball;
    public float ballSpeed=50.0f;
    private int count=0;
    float rotationSpeed=10.0f;//方向回転スピード
    float canonballDelay=10.0f; //最初のcanonballが出るまでの待機時間
    float delayTimer=0f;//待機時間計算用
    //最初のcanonballが出現したかどうか
    bool firstCanonball;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       //遅延コルーチンを開始
       StartCoroutine(CanonballDelay());
       firstCanonball=false;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            //transform.LookAt(player);//プレイヤーの方を向く(速度調整できない)
            
            //プレイヤーの方向への回転を計算
            Quaternion targetRotation=Quaternion.LookRotation(player.position-transform.position);
            //プレイヤーの方向に滑らかに回転
            transform.rotation=Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime*rotationSpeed
            );
            //delayTimerを増加
            delayTimer+=Time.deltaTime;
            count++;
            //Debug.Log(count);
            //最初のcanonballが出ていないか&待機時間達したか確認
            if(!firstCanonball&&delayTimer>=canonballDelay){
                //最初のcanonballを出現させる
                Instantiate(
                    canonball,
                    transform.position,
                    Quaternion.identity
                    );
                    firstCanonball=true;//最初のcanonballが出現したこと
            }
                //連射間隔
                if(count%ballSpeed==0){
                //canonballを出現させる
                Instantiate(
                    canonball,
                    transform.position,
                    Quaternion.identity
                    );
            }
            //タイマーをリセット
            delayTimer=0f;
        }
    }
    //遅延コルーチン：指定した待機時間後に最初のcanonballを出現させる
    IEnumerator CanonballDelay(){
        yield return new WaitForSeconds(canonballDelay);
        Instantiate(
            canonball,
            transform.position,
            Quaternion.identity
        );
        firstCanonball=true;
    }
    void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            //animator.SetTrigger("attack");           
        }
    }
}
