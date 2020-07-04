using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] protected Image progressBar;
    public float FillAmount { get { return progressBar.fillAmount; } }
    protected float Decrease(float value)
    {
        return progressBar.fillAmount -= 1 / value * Time.deltaTime;
    }
    protected float Amount { get { return progressBar.fillAmount; } }
    protected void TimeReset()
    {
        progressBar.fillAmount = 1;
    }

    protected void AddProgress(float value)
    {
        if (1 / value > 1)
        {
            value = 1;
        }
        progressBar.fillAmount += 1 / value;
    }
}
