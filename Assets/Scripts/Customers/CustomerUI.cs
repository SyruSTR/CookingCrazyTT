using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerUI : UIProgressBar
{
    [SerializeField] private GameObject[] menuSprites;
    private List<GameObject> dishes = new List<GameObject>();
    private Customer.Menu[] order;
    void Start()
    {
        UpdateOrder();

    }
    public void AddTime()
    {
        AddProgress(6f);
    }
    private void UpdateOrder()
    {
        if (gameObject.transform.GetChild(0).gameObject.transform.childCount > 2)
        {
            foreach (var item in dishes)
            {
                Destroy(item.gameObject);
            }
        }
        order = GetComponent<Customer>().Order;

        for (int i = 0; i < order.Length; i++)
        {
            dishes.Add((Instantiate(menuSprites[(int)order[i]],
                gameObject.transform.GetChild(0).transform.position + new Vector3(0, i - 1, 0),
                Quaternion.identity,
                gameObject.transform.GetChild(0))));
        }
    }

    void Update()
    {
        if (Decrease(GetComponent<Customer>().WaitingTime) <= 0 || order.Length <= 0)
        {
            CustomersController customer = GetComponent<Customer>().CustomersController;
            if (FillAmount <= 0)
                customer.MenuController.NotServedCustomers = 1;
            if (customer.CountCustomers > 0)
            {
                customer.SendMessage("AddCustomer");
            }
            customer.MenuController.NumberOfServedCustomers = 1;
            Destroy(gameObject);
            return;
        }
    }
}
