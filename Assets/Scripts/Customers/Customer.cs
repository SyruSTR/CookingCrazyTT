using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private List<Menu> order;
    [SerializeField] private CustomersController customersController;
    public CustomersController CustomersController { get { return customersController; } set { customersController = value; } }
    [SerializeField] private int waintingTime = 18;
    [SerializeField] private int idCustomer;
    public enum Menu
    {
        Burger,
        HotDog,
        Cola
    }
    public float WaitingTime { get { return waintingTime; } }
    public int ID { get { return idCustomer; } }

    public Menu[] Order { get { return order.ToArray(); } }
    public int CountDishes
    {
        get
        {
            RandomDish();
            return order.Count;
        }
    }
    public void DestroyDish(int index)
    {
        order.RemoveAt(index);
        customersController.GivedDishes++;
        GetComponent<CustomerUI>().SendMessage("UpdateOrder");
        if (order.Count > 0)
            GetComponent<CustomerUI>().AddTime();
    }
    public void RandomDish()
    {
        int CountDishes = Random.Range(1, 5);
        switch (CountDishes)
        {
            case 1:
            case 2:
                CountDishes = 1;
                break;
            case 3:
                CountDishes = 2;
                break;
            case 4:
                CountDishes = 3;
                break;
        }
        for (int i = 0; i < CountDishes; i++)
        {
            switch (Random.Range(0, 5))
            {
                case 0:
                case 1:
                    order.Add(Menu.Burger);
                    break;
                case 2:
                case 3:
                    order.Add(Menu.HotDog);
                    break;
                case 4:
                    order.Add(Menu.Cola);
                    break;
            }
        }

    }
}
