using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{  
    [SerializeField] PlayerController playerController;
    
    public Slider sliderExp;

    void Start()
    {
        //SliderのValueを0にする
        sliderExp.value = 0;
    }

    void Update()
    {
        //expの値をスライダーに反映させる
        sliderExp.value = playerController.PlayerExp;
        //Debug.Log(playerController.PlayerExp);
        //sliderExp.value += 0.01f;
        
    }
}
