using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Transform player;
    public GameObject canonball;
    private int count=0;
    float rotationSpeed=5f;//方向回転スピード
    //float canonballDelay=2f; //最初のcanonballが出るまでの待機時間
    //float delayTimer=0f;//待機時間計算用
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.name=="Player"){
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
            //delayTimer+=Time.deltaTime;
            count++;
            Debug.Log(count);
            //canonballの待機時間達したか確認
            //if(delayTimer>=canonballDelay){
                //連射間隔
                if(count%20==0){
                    //canonballを出現させる
                    Instantiate(
                        canonball,
                        transform.position,
                        Quaternion.identity
                        );
                }
            
            //}
            //タイマーをリセット
            //delayTimer=0f;
        }
    }
}
