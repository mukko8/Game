using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLuncher : MonoBehaviour
{
    public GameObject Bullet;
    public void BulletShot(){
        Instantiate(Bullet,transform.position,Quaternion.identity);
    }       
}
