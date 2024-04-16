using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonballController : MonoBehaviour
{
    private GameObject player;
    public int canonDamage=10;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        transform.LookAt(player.transform); //プレイヤーの方を向く
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,0.05f);//発射スピード
        Destroy(gameObject,3f);
    }
    /*void OnTriggerEnter(Collider other){
        int pc = other.GetComponent<PlayerController>().playerHp;
        if (other.gameObject.CompareTag("Player")){
            //Debug.Log("射撃");
            pc-=canonDamage;//HPを減らす　//enemyHPはplayer側の変数に変更
            if(pc<=0){
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject);
    }
    */

}
