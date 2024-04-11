using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpController : MonoBehaviour
{
    public float maxHP=100f;//最大HP
    private float enemyHP;//現在のHP
    // Start is called before the first frame update
    void Start()
    {
        enemyHP=maxHP;//初期HPを最大HPに設定
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage){
        enemyHP-=damage;//HPを減らす
        if(enemyHP<=0){
            Destroy(gameObject);
        }
    }
}
