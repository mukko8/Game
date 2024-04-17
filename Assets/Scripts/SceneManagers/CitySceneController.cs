using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CitySceneController : MonoBehaviour
{
    [SerializeField] Transform enemies;
    [SerializeField] PlayerController pc;
    [SerializeField] GameObject clearText;

    void Start()
    {
        clearText.SetActive(false);
    }

    void LateUpdate()
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < enemies.childCount; i++)
        {
            children.Add(enemies.GetChild(i));
        }

        if (children.Count <= 0)
        {
            pc.enabled = false;
            clearText.SetActive(true);
        }
        else if (pc.PlayerHp <= 0)
        {
            Invoke("LoseScene",1.0f);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync("Mountain");
    }

    void LoseScene()
    {
        SceneManager.LoadSceneAsync("LoseScene");
    }

}
