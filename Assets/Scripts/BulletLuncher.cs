using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLuncher : MonoBehaviour
{
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;

    public void BulletShot(int weponIndex){
        switch(weponIndex){
            case 0:
                Instantiate(b1,transform.position,Quaternion.identity);
                break;
            case 1:
                for(int i =0;i<8;i++){
                    Instantiate(b2,transform.position,Quaternion.identity);
                }
                break;
            case 2:
                Instantiate(b3,transform.position,Quaternion.identity);
                break;
        }
    }     
    

}
