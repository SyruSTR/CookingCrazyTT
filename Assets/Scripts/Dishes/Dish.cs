using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField] private CookingController cookingController;
    public CookingController CookingController { set { cookingController = value; } }
    [SerializeField] private bool finishDish = false;
    [SerializeField] private GameObject meat;

    public bool FinishDish
    {
        get { return finishDish; }
        set
        {
            finishDish = value;
            meat.SetActive(finishDish);
        }
    }
}
