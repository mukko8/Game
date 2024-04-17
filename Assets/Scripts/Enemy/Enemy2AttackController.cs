using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AttackController : MonoBehaviour
{
    [SerializeField] float attackInterval = 20; // 攻撃間隔
    [SerializeField] PlayerController pc;
    [SerializeField] EnemyStatus es;

    private float timer;

    void Update()
    {
        if (es.EnemyHP <= 0)
        {
            GameObject boss = GameObject.Find("BOSS");
            if (boss != null)
            {
                DestroyAllEnemies();
            }
            Destroy(gameObject);
        }
    }

    void DestroyAllEnemies()
    {//BOSSがやられたらほかのEnemyも消える
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            //if(enemy.name=="BOSS"){
            Destroy(enemy);
            //}
        }
    }
}
