using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public float damage=10f;
    private void OnCollisionEnter(Collision collision){
        //衝突した相手オブジェクトにHpControllerコンポーネントがアタッチされているか確認
        HpController hp=collision.gameObject.GetComponent<HpController>();
        if(hp!=null){
            //ダメージを与える
            hp.TakeDamage(damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
