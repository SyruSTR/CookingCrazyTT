using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : UIProgressBar
{
    [SerializeField] private CustomersController customersController;
    [SerializeField] private EndGame endGame;
    [SerializeField] private int countCustomers;
    public int CountCustomers { set { countCustomers = value; } }
    [SerializeField] private int allServedCustomers;
    [SerializeField] private int notServedCustomers;
    public int NotServedCustomers { set { notServedCustomers += value; } }
    public int NumberOfServedCustomers
    {
        get { return allServedCustomers; }
        set
        {
            allServedCustomers += value;
            UpdateNumberOfServed();
        }
    }
    [Space]
    [SerializeField] private Text countCustomersText;
    [SerializeField] private Text allServedCustomersText;

    void Start()
    {
        notServedCustomers = 0;
        allServedCustomers = 0;
        countCustomersText.text = countCustomers.ToString();
        allServedCustomersText.text = allServedCustomers.ToString() + "/" + countCustomers;
    }

    private void UpdateNumberOfServed()
    {
        allServedCustomersText.text = allServedCustomers.ToString() + "/" + countCustomers;
        countCustomersText.text = (countCustomers - allServedCustomers).ToString();
        //Debug.LogWarning("DishedCount: " + customersController.CountDished);
        AddProgress(countCustomers);
        if (allServedCustomers + notServedCustomers == 15)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        Debug.LogWarning("EndGame" + "\nDishedCount: " + customersController.CountDished);
        endGame.End(customersController.GivedDishes, customersController.CountDished - 2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
