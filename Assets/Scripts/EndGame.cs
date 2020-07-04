using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : UIProgressBar
{
    [Space]
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text winLoseText;
    [SerializeField] private Text CountTargetText;
    [Space]
    [SerializeField] private Image shef;
    [SerializeField] private Sprite winShef;
    [SerializeField] private Sprite loseShef;
    [Space]
    [SerializeField] private Image winLoseIcon;
    [SerializeField] private Sprite winIcon;
    [SerializeField] private Sprite loseIcon;
    public void End(float countDishes, float countTarget)
    {
        canvas.SetActive(true);

        //it's not work why!!!???
        //AddProgress((countTarget * countDishes));
        for (int i = 0; i < countDishes; i++)
        {
            AddProgress(countTarget);
        }

        CountTargetText.text = countDishes.ToString() + "/" + countTarget.ToString();
        if (countDishes >= countTarget)
        {
            winLoseText.text = "Вы выигравили!";
            shef.sprite = winShef;
            winLoseIcon.sprite = winIcon;
        }
        else
        {
            winLoseText.text = "Вы проиграли!";
            shef.sprite = loseShef;
            winLoseIcon.sprite = loseIcon;
        }
        Time.timeScale = 0;
    }
}
