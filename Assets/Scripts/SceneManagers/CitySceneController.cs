using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CitySceneController : MonoBehaviour
{
    public Transform parent;
    public AttackController attackControlelr;

    void Start()
    {
        //Invoke("ChangeScene",2.0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < parent.childCount; i++)
        {
            children.Add(parent.GetChild(i));
        }

        if (children.Count <= 0)
        {
            ChangeScene();
        }
        else if (attackControlelr.playerHp<= 0)
        {
            LoseScene();
        }

    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync("Mountain");
    }

    void LoseScene()
    {
        SceneManager.LoadSceneAsync("LoseScene");
    }

}
