using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3Controller : MonoBehaviour
{
    public Transform player;
    public GameObject canonball;
    public float ballSpeed=4f;
    public float enemyHP=30.0f;
    private int count=0;
    Animator animator;
    //索敵範囲
    public float traceDist =15.0f;
    //停止するプレイヤーとの距離
    public float stopDist=5.0f;
    float rotationSpeed=10f;//方向回転スピード
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //毎フレーム距離の計測をする必要はないのでコルーチンで行う。
        StartCoroutine(CheckDist());
    }
    IEnumerator CheckDist()
    {
        while (true)
        {
            //1秒間に5回距離を計測する。
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
                //プレイヤーからstopDist離れた位置を目的地に設定
                Vector3 targetPosition=player.position+(transform.position-player.position).normalized*stopDist;
                nav.SetDestination(targetPosition);
                count++;
                
                if(dist<stopDist){
                    //プレイヤーの方向への回転を計算
                    RotationCalc();
                    //y軸回転
                    transform.rotation=Quaternion.Euler(0f,targetRotation.eulerAngles.y,0f);
                    //追跡を辞める
                    nav.isStopped=true;
                    //連射間隔
                    if(count%ballSpeed==0){
                        //canonballを出現させる
                        Instantiate(
                        canonball,
                        transform.position,
                        Quaternion.identity
                        );
                    }
                }else{
                    //追跡再開
                    nav.isStopped=false;
                }
            }
            else
            {
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


