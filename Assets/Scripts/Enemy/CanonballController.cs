using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonballController : MonoBehaviour
{
    private GameObject player;
    public AttackController ac;
    float canonDamage;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        transform.LookAt(player.transform); //プレイヤーの方を向く
        this.ac = GetComponent<AttackController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,0.15f);//発射スピード
        Destroy(gameObject,3f);
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("射撃");
            canonDamage=ac.damage;
            ac.TakeDamage(canonDamage);
        }
        Destroy(gameObject);
    }

}
