using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola : MonoBehaviour
{
    [SerializeField] private int fillingTime;
    [Space]
    [SerializeField] private GameObject fullCola;
    [SerializeField] private bool full;

    public float FillingTime { get { return fillingTime; } }
    public bool Full
    {
        get { return full; }
        set
        {
            full = value;
            FullCola(full);
        }
    }
    public void FullCola(bool _full)
    {
        Debug.Log("Cola Full");
        fullCola.SetActive(_full);
        gameObject.transform.GetChild(0).gameObject.SetActive(!_full);
    }
    private void GiveCola()
    {
        if (full)
        {
            full = false;
            FullCola(false);
            GetComponent<ColaUI>().SetTime();
        }
    }
}
