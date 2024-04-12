using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float maxHP=100f;//最大HP
    private float currentHP;//現在のHP
    public float damage=10f;//与えるダメージ
    private void OnTriggerEnter(Collider other){
        if(currentHP!=0){
            //ダメージを与える
            TakeDamage(damage);
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
        currentHP-=damage;//HPを減らす
        if(currentHP<=0){
            Destroy(gameObject);
        }
    }
}
