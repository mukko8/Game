using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 40.0f;
    public float bulletDamage = 10;
    public GameObject bullet;
    public GameObject HitEffect;
    public Enemy1Controller en1;

    GameObject bl;
    Ray ray;
    RaycastHit hit;

    public void Shot()
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
        //bulletを生成して飛ばす
        bl = Instantiate(bullet,transform.position,Quaternion.identity);
        bl.GetComponent<Rigidbody>().velocity=(ray.direction+ofset).normalized* bulletSpeed;
        
        //Debug.Log(hit.distance);
        Destroy(bl,1.0f);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            //other.gameObject.enemyHP =0;
            other.gameObject.GetComponent<Enemy1Controller>().enemyHP -= bulletDamage;
            if(other.gameObject.GetComponent<Enemy1Controller>().enemyHP<=0){
                Destroy(other.gameObject);
            }
        }
        Destroy(bl);
        Instantiate(HitEffect, hit.point, Quaternion.identity);
        Destroy(HitEffect,0.5f);
    }


}
