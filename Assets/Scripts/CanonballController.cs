using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonballController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        transform.LookAt(player.transform); //プレイヤーの方を向く
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,0.5f);//発射スピード
        Destroy(gameObject,1);
    }
}
