using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public int maxHP=100;//最大HP
    public int enemyHP;//現在のHP
    public int damage=10;//与えるダメージ
    public float attackInterval = 20; // 攻撃間隔
    public GameObject player; // GameObject "player" を定義
    public PlayerController playerController;
    public float playerHp = 150;
    private float timer;
    void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Player")&&playerHp!=0)//enemyHPはplayer側の変数に変更
        {
            Debug.Log("第１のif文");
            timer += Time.deltaTime*10;
            Debug.Log(timer);
            if (timer >= attackInterval){
                timer = 0;
                Debug.Log("第２のif文");
                //animator.SetTrigger("attack");
                //Debug.Log("攻撃");
                playerHp-=damage;//HPを減らす　//enemyHPはplayer側の変数に変更
                Debug.Log("ダメージを受けたpcのHp"+playerHp);
                if(playerHp<=0){
                    Debug.Log("第３のif文");
                    Destroy(other.gameObject);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyHP=maxHP;//初期HPを最大HPに設定
        playerHp = player.GetComponent<PlayerController>().playerHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHP<=0){
            GameObject boss = GameObject.Find("BOSS");
            if(boss!=null){
                DestroyAllEnemies();
            }
            Destroy(gameObject);
        }
    }
    void DestroyAllEnemies(){//BOSSがやられたらほかのEnemyも消える
        GameObject[] enemies=GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            //if(enemy.name=="BOSS"){
                Destroy(enemy);
            //}
        }   
    }
}
