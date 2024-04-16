using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Controller : MonoBehaviour
{
    public Transform player;
    //索敵範囲
    public float traceDist =15.0f;
    float rotationSpeed=10.0f;//方向回転スピード
    NavMeshAgent nav;
    Animator animator;

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
            yield return new WaitForSeconds(0.2f);
            //プレイヤーとの距離を計測
            float dist = Vector3.Distance(player.position, transform.position);
            //索敵範囲に入ったか？
            if (dist < traceDist)
            {
                //プレイヤーの方向への回転を計算
                Quaternion targetRotation=Quaternion.LookRotation(player.position-transform.position);
                //プレイヤーの方向に滑らかに回転
                transform.rotation=Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime*rotationSpeed
                    );
                //プレイヤーの位置を目的地に設定
                nav.SetDestination(player.position);
                //追跡再開
                nav.isStopped=false;
            }
            else
            {
                //探索範囲から出たら追跡終了
                nav.isStopped=true;
            }
        }
        
    }
}

