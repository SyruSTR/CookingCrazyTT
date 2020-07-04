using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedMeat : MonoBehaviour
{
    enum DegreOfFrying
    {
        raw,
        cooking,
        overcooking
    }

    [SerializeField] private CookingController cookedContr;
    public CookingController cookingController { set { cookedContr = value; } }
    [Space]
    [SerializeField] private CookingController.Meats meat;
    [Space]
    [SerializeField] private int cookingTime = 5;
    [SerializeField] private int overcookingTime = 7;
    [Space]
    [SerializeField] private Sprite cookingSprite;
    [SerializeField] private Sprite overcookingSprite;
    [Space]
    [SerializeField] private DegreOfFrying degreOfFrying = 0;

    public float CookingTime { get { return cookingTime; } }
    public float OvercookingTime { get { return overcookingTime; } }

    void OnMouseDown()
    {
        if (degreOfFrying == DegreOfFrying.cooking)
        {
            Debug.Log("Click " + degreOfFrying);
            //true means success
            if (cookedContr.AddMeat(meat))
                Destroy(gameObject);
        }
    }

    public void Cooking()
    {
        degreOfFrying = DegreOfFrying.cooking;
        GetComponent<SpriteRenderer>().sprite = cookingSprite;
    }
    public void OVercooking()
    {
        degreOfFrying = DegreOfFrying.overcooking;
        GetComponent<SpriteRenderer>().sprite = overcookingSprite;
    }
}
