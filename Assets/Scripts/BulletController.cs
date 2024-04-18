using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 40;
    [SerializeField] float bulletDamage = 10;
    [SerializeField] GameObject HitEffect;
    public PlayerController player;
    private EnemyStatus es;

    Ray ray;
    RaycastHit hit;

    public void Start()
    {
        //画面の中心に向かってraycastを飛ばす
        ray = Camera.main.ScreenPointToRay(
            Camera.main.ViewportToScreenPoint(Camera.main.rect.center)
        );
        //対象との距離と縦方向の向きに応じて発射角度に補正をつける
        Vector3 ofset = new Vector3(0, 0.1f, 0);
        if (Physics.Raycast(ray, out hit, 100f) && hit.distance >= 5.0f)
        {
            ofset.y = 3.1f / hit.distance + Camera.main.transform.forward.y / 3.0f;
        }
        //bulletを飛ばす
        gameObject.GetComponent<Rigidbody>().velocity = (ray.direction + ofset).normalized * bulletSpeed;

        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            es = other.GetComponent<EnemyStatus>();
            es.Damage(bulletDamage);
      
        }
        Destroy(gameObject);
        Instantiate(HitEffect, hit.point, Quaternion.identity);
        
        Destroy(HitEffect, 0.5f);

    }

}
