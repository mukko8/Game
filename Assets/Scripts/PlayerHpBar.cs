using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    private float maxHp;
    public Slider slider;

    void Start()
    {
        //SliderのValueを最大にする
        slider.value = 1;
        //currentHpをMaxHpにする
        maxHp = playerController.PlayerHp;

    }

    void Update()
    {
        //ダメージを受ければ、MaxHpとの割合でsliderを移動させる
        slider.value = playerController.PlayerHp/maxHp;
    }
}
