using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float maxHP=100f;//最大HP
    private float currentHP;//現在のHP
    public float damage=10f;//与えるダメージ
    //playerのHP
    /*
    PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
    float currentPlayerHP = playerHealth.playerHP
    */
    public float attackInterval = 20; // 攻撃間隔
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")&&currentHP!=0)//currentHPはplayer側の変数に変更
        {
            //if (Time.frameCount % attackInterval == 0){
            //animator.SetTrigger("attack");
            Debug.Log("攻撃");
            TakeDamage(damage);
            //}
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHP=maxHP;//初期HPを最大HPに設定
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage){
        // 敵のHPをプレイヤーのatk分、減少させる
       //enemyHP -= playerstates.atk
        currentHP-=damage;//HPを減らす　//currentHPはplayer側の変数に変更
        if(currentHP<=0){
            Destroy(gameObject);
        }
    }
}
