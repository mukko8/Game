using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //public GameObject player;
    //public GameObject Bullet;
    public GameObject HitEffect;
    Ray ray;
    
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
    //画面の中心に向かってraycastを飛ばす
        ray = Camera.main.ScreenPointToRay(
            Camera.main.ViewportToScreenPoint(Camera.main.rect.center)
        );
        //対象との距離に応じて角度に補正をつける
        Vector3 ofset = new Vector3(0,0.01f,0);
        if(Physics.Raycast(ray,out hit, 100f) &&hit.distance>=5.0f) {
            ofset.y =3.1f/hit.distance;
        }
        //bulletを飛ばす
        GetComponent<Rigidbody>().velocity=(ray.direction+ofset).normalized* 40.0f;
        
        Debug.Log(hit.distance);
        Destroy(gameObject,1.0f);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
        Instantiate(HitEffect, hit.point, Quaternion.identity);
        Destroy(HitEffect,0.5f);
    }


}
