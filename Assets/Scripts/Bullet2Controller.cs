using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Controller : MonoBehaviour
{
    public float bulletSpeed = 50.0f;
    public float bulletDamage = 3;
    public GameObject bullet;
    public GameObject HitEffect;
    public Enemy1Controller en1;
    Ray ray;
    
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
    //画面の中心に向かってraycastを飛ばす
        ray = Camera.main.ScreenPointToRay(
            Camera.main.ViewportToScreenPoint(Camera.main.rect.center)
        );
        //対象との距離と縦方向の向きに応じて発射角度に補正をつける
        Vector3 ofset = new Vector3(0,0.1f,0);
        if(Physics.Raycast(ray,out hit, 100f) &&hit.distance>=5.0f) {
            ofset.y =3.1f/hit.distance + Camera.main.transform.forward.y/3.0f;
        }
        
        Instantiate(bullet,transform.position,Quaternion.identity);
        //bulletを飛ばす
        bullet.GetComponent<Rigidbody>().velocity=(ray.direction+ofset).normalized* bulletSpeed;
        
        //Debug.Log(hit.distance);
        Destroy(bullet,0.5f);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            //other.gameObject.enemyHP =0;
            other.gameObject.GetComponent<Enemy1Controller>().enemyHP -= bulletDamage;
            if(other.gameObject.GetComponent<Enemy1Controller>().enemyHP<=0){
                Destroy(other.gameObject);
            }
        }
        Destroy(bullet);
        Instantiate(HitEffect, hit.point, Quaternion.identity);
        Destroy(HitEffect,0.5f);
    }
}
