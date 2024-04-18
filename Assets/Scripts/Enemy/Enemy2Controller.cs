using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Controller : MonoBehaviour
{
    public Transform player;
    public GameObject canonball;
    public float ballSpeed=10.0f;
    private int count=0;
    //索敵範囲
    public float traceDist =30.0f;
    float rotationSpeed=30.0f;//方向回転スピード
    NavMeshAgent nav;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       //firstCanonball=false;//初期化
       nav = GetComponent<NavMeshAgent>();
        //毎フレーム距離の計測をする必要はないのでコルーチンで行う。
        StartCoroutine(CheckDist());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CheckDist()
    {
        while (true)
        {
            //1秒間に10回距離を計測する。
            yield return new WaitForSeconds(0.1f);
            //プレイヤーとの距離を計測
            float dist = Vector3.Distance(player.position, transform.position);
            
            //索敵範囲に入ったか？
            if (dist < traceDist)
            {
                RotationCalc();
                //プレイヤーの方向への回転を計算
                Quaternion targetRotation=Quaternion.LookRotation(player.position-transform.position);
                //プレイヤーの方向に滑らかに回転
                transform.rotation=Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime*rotationSpeed
                );
                count++;
                //Debug.Log(count);
                
                //連射間隔
                if(count%ballSpeed==0){
                //canonballを出現させる
                Instantiate(
                    canonball,
                    transform.position,
                    Quaternion.identity
                    );
                }
                    
            }
                //タイマーをリセット
                //delayTimer=0f;
            else{
                //探索範囲から出たら追跡終了
                nav.isStopped=true;
            }
        }
    }
    void RotationCalc(){
        //プレイヤーの方向への回転を計算
        Quaternion targetRotation=Quaternion.LookRotation(player.position-transform.position);
    }
}

