using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class S1EnemyGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject Enemy1;
    public GameObject Enemy4;
    public float span=2.0f;
    float delta=0;
    public float dist=20f;//敵が生成されるプレイヤーからの距離
    public int EnemySum=100;//出現する敵の数
    GameObject item;

    void Update()
    {
        this.delta+=Time.deltaTime;
        if(this.delta>this.span){
            this.delta=0;
            int dice=Random.Range(1,6);//1~5
            if(dice<=3){
                item=Instantiate(Enemy1);
            }else{
                item=Instantiate(Enemy4);
            }
            //Prefabのy座標取得
            float prefabY=item.transform.position.y;
            
            //プレイヤーからdist離れたとこにランダムで生成
            float x=Random.Range(player.position.x-dist,player.position.x+dist);
            float z=Random.Range(player.position.z-dist,player.position.z+dist);
            item.transform.position=new Vector3(x,prefabY,z);
            EnemySum--;
            if(EnemySum==0){
                enabled=false;//Updateを停止する
            }
        }   
    }
}