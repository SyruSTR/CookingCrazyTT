using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{

    public float firstClickTime, timeBetweenClicks;
    private bool corotineAllowed, clickInObject;
    private int clickCounter;

    void Start()
    {
        firstClickTime = 0f;
        timeBetweenClicks = 0.2f;
        clickCounter = 0;
        corotineAllowed = true;
        clickInObject = false;
    }

    void OnMouseDown()
    {
        clickInObject = true;
    }
    void Update()
    {

        if (Input.GetMouseButtonUp(0) && clickInObject)
        {
            clickCounter++;

        }
        if (clickCounter == 1 && corotineAllowed)
        {
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }

    }
    private IEnumerator DoubleClickDetection()
    {
        corotineAllowed = false;
        while (Time.time < firstClickTime + timeBetweenClicks)
        {
            if (clickCounter == 2)
            {
                Debug.Log("double click");
                Destroy(gameObject);
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        clickCounter = 0;
        firstClickTime = 0f;
        corotineAllowed = true;
        clickInObject = false;
    }

}


