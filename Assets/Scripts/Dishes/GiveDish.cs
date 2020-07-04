using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GiveDish : MonoBehaviour
{
    [SerializeField] private CookingController cookingController;
    [SerializeField] private Customer.Menu dish;
    public CookingController CookingController { set { cookingController = value; } }

    void OnMouseDown()
    {
        if (GetComponent<Dish>() != null)
        {
            if (GetComponent<Dish>().FinishDish)
            {
                Debug.Log("Give HotDog or Burger");
                CheckDish(false);
            }
        }
        else if (GetComponent<Cola>() != null)
        {
            if (GetComponent<Cola>().Full)
            {
                Debug.Log("Give Cola");
                CheckDish(true);
            }
        }
    }
    private void CheckDish(bool itsCola)
    {
        if (cookingController.GiveDish(dish))
            if (!itsCola)
                Destroy(gameObject);
            else GetComponent<Cola>().SendMessage("GiveCola");
    }
}
