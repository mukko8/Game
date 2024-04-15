using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveSceneController : MonoBehaviour
{
    public Transform parent;
    public AttackController attackController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        else if(attackController.playerHp<= 0)
        {
            LoseScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("ClearScene");
    }

    void LoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
