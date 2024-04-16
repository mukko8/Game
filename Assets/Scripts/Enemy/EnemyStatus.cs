using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] float maxHP = 100;//最大HP
    public float MaxHp { get { return maxHP; } }

    [SerializeField] float enemyHP;//現在のHP
    public float EnemyHP { get { return enemyHP; } }

    [SerializeField] float attack = 10;//与えるダメージ
    public float Attack{ get { return attack; } }

    void Start()
    {
        enemyHP = maxHP;
    }

    public void Damage(float value)
    {
        enemyHP -= value;
    }
}
