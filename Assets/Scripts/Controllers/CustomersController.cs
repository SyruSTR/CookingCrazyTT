using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersController : MonoBehaviour
{
    [SerializeField] private MenuController menuController;
    public MenuController MenuController { get { return menuController; } }
    [Space]
    [SerializeField] private Transform[] customersPosition;
    [SerializeField] private List<GameObject> customers = new List<GameObject>();
    [Space]
    [SerializeField] private int timeAppearance;
    public int TimeAppearance { get { return timeAppearance; } }
    [SerializeField] private int totalCustomers;
    [SerializeField] private int countCustomers;
    [SerializeField] private int countDishes;
    public int CountDished { get { return countDishes; } }
    private int givedDishes;
    public int GivedDishes { get { return givedDishes; } set { givedDishes = value; } }
    public int CountCustomers { get { return countCustomers; } }
    [Space]
    [SerializeField] private GameObject[] custPrefab;

    void Awake()
    {
        countCustomers = totalCustomers;
        menuController.CountCustomers = countCustomers;
    }
    void Start()
    {
        countDishes = 0;
        StartCoroutine(AddCustomer(timeAppearance));
    }
    private void AddCustomer()
    {
        StartCoroutine(AddCustomer(timeAppearance));
    }
    public IEnumerator AddCustomer(int second)
    {
        if (countCustomers <= 0)
        {
            Debug.Log("Closed");
            yield break;
        }
        yield return new WaitForSeconds(second);
        if (countCustomers > 0)
        {
            Debug.Log("New Customer");
            for (int i = 0; i < customersPosition.Length; i++)
            {
                if (customersPosition[i].transform.childCount == 0)
                {
                    if (customersPosition[i].transform.childCount < 1)
                    {
                        GameObject newCust = Instantiate(custPrefab[Random.Range(0, custPrefab.Length)], customersPosition[i].position, Quaternion.identity, customersPosition[i]);
                        customers.Add(newCust);
                        newCust.GetComponent<Customer>().CustomersController = this;
                        countDishes += newCust.GetComponent<Customer>().CountDishes;
                        Debug.LogWarning("Count Dishes: " + countDishes);
                        countCustomers--;
                        Debug.Log("Count Customers: " + countCustomers);
                        break;
                    }
                }
            }
        }
        if (countCustomers > 0)
        {
            if (customers.Count < 4)
                StartCoroutine(AddCustomer(timeAppearance));
        }
    }

    public bool CheckOrders(Customer.Menu dish)
    {
        float min = 18;
        int index = -1;
        int indexCustomer = -1;
        for (int i = 0; i < customers.Count; i++)
        {
            if (customers[i] != null)
            {
                var order = customers[i].GetComponent<Customer>().Order;
                float waitTime = customers[i].transform.GetChild(0).transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().fillAmount * 18;
                for (int j = 0; j < order.Length; j++)
                {
                    if (dish == order[j] && waitTime < min)
                    {
                        min = waitTime;
                        index = j;
                        indexCustomer = i;
                    }
                }
            }
        }
        if (min < 18)
        {
            customers[indexCustomer].GetComponent<Customer>().DestroyDish(index);

            return true;
        }
        return false;
    }
}
