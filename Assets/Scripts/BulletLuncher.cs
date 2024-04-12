using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLuncher : MonoBehaviour
{
    public BulletController b1;
    public Bullet2Controller b2;
    public void BulletShot(int weponIndex){
        switch(weponIndex){
            case 0:
               b1.Shot();
            break;
            case 1:
            break;
        }
    }       
}
