using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CitySceneController : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Collider[] colls = Physics.OverlapSphere(new Vector3(0,0,0),300);
        foreach(Collider coll in colls)
        {
            if(coll.tag == "Enemy")
            {
                Debug.Log("Enemy is Coming");
            }
        }
        */
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync("Mountain");
    }

}
