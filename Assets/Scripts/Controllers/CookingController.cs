using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : MonoBehaviour
{
    public enum Meats
    {
        burger,
        sosige
    }
    [SerializeField] private GameObject[] burgers;
    [SerializeField] private GameObject[] hotDog;
    [Space]
    [SerializeField] private GameObject[] burgersBoards;
    [SerializeField] private GameObject[] hotDogBoards;
    [SerializeField] private GameObject[] cola;
    [Space]
    [SerializeField] private GameObject burgerBrefab;
    [SerializeField] private GameObject hotDogBrefab;

    void Start()
    {
        for (int i = 0; i < cola.Length; i++)
        {
            cola[i].GetComponent<GiveDish>().CookingController = this;
        }
    }
    public void AddDish(Meats meat)
    {
        if (meat == Meats.burger)
        {
            for (int i = 0; i < burgers.Length; i++)
            {
                if (burgers[i] == null)
                {
                    Debug.Log("Add Burger");
                    burgers[i] = Instantiate(burgerBrefab, burgersBoards[i].transform.position, Quaternion.identity, burgersBoards[i].transform);
                    return;
                }
            }
        }
        else if (meat == Meats.sosige)
        {
            for (int i = 0; i < hotDog.Length; i++)
            {
                if (hotDog[i] == null)
                {
                    Debug.Log("Add HotDog");
                    hotDog[i] = Instantiate(hotDogBrefab, hotDogBoards[i].transform.position, Quaternion.identity, hotDogBoards[i].transform);
                    return;
                }
            }
        }
    }
    public bool AddMeat(Meats meat)
    {
        Debug.Log("it is " + meat);
        if (meat == Meats.burger)
        {
            return FindEmptyBread(burgersBoards);
        }
        else if (meat == Meats.sosige)
        {
            return FindEmptyBread(hotDogBoards);
        }
        return false;
    }
    private bool FindEmptyBread(GameObject[] breads)
    {
        for (int i = 0; i < breads.Length; i++)
        {
            if (breads[i].transform.childCount != 0)
            {
                if (breads[i].transform.childCount < 2 &&
                    !breads[i].GetComponentInChildren<Dish>().FinishDish)
                {
                    breads[i].GetComponentInChildren<Dish>().FinishDish = true;
                    breads[i].GetComponentInChildren<GiveDish>().CookingController = this;
                    return true;
                }
            }
        }
        return false;
    }

    public bool GiveDish(Customer.Menu dish)
    {
        //Debug.LogError(GetComponentInParent<ControllerControllers>().CustomersController == null);

        return transform.parent.transform.GetChild(1).GetComponent<CustomersController>().CheckOrders(dish);
    }
}
