using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    public float maxHP=100f;//最大HP
    private float currentHP;//現在のHP
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
