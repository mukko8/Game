using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonballController : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;
    public float canonDamage = 10;
    public int destroyTime = 3;
    public float canonSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform); //プレイヤーの方を向く
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, canonSpeed);//発射スピード
        Destroy(gameObject, destroyTime);
    }


    void OnTriggerEnter(Collider other)
    {
        pc = other.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player"))
        {
            pc.Damege(canonDamage);
            if (pc.PlayerHp <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }


}
