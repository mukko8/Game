using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MountainSceneController : MonoBehaviour
{
    [SerializeField] Transform enemies;
    [SerializeField] PlayerController pc;

    void Update()
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < enemies.childCount; i++)
        {
            children.Add(enemies.GetChild(i));
        }

        if (children.Count <= 0)
        {
            ChangeScene();
        }
        else if (pc.PlayerHp <= 0)
        {
            LoseScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync("Cave");
    }

    void LoseScene()
    {
        SceneManager.LoadSceneAsync("LoseScene");
    }

}
