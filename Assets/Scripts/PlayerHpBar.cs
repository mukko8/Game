using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    //ここら辺は仮で実装するので後で要改修
    float MaxHp;
    public float currentHp;
    public Slider slider;
    public PlayerController playerController;

    void Start()
    {
        //SliderのValueを最大にする
        slider.value = 1;
        //PlayerControllerで設定されているHPを最大HPとする
        MaxHp = (float)playerController.playerHp;
        //現在のHPを最大HPと同じにする
        currentHp = MaxHp;
    }

    void Update()
    {
        //ダメージを受ければ、MaxHpとの割合でsliderを移動させる
        slider.value = currentHp / MaxHp;
    }
}
