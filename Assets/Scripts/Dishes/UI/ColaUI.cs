using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColaUI : UIProgressBar
{
    private Cola colaComp;

    void Start()
    {
        colaComp = GetComponent<Cola>();
    }
    public void SetTime()
    {
        TimeReset();
    }
    void Update()
    {
        if (Amount == 0 && colaComp.Full == false)
        {
            colaComp.Full = true;
        }
        Decrease(colaComp.FillingTime);
    }
}
