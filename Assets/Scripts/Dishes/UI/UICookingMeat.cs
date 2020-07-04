using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICookingMeat : UIProgressBar
{

    [SerializeField] private Image backCooked;
    private CookedMeat meat;
    [Space]
    [SerializeField] private Sprite progressBarOvercooked;
    [SerializeField] private Sprite backOvercooked;
    private bool overcooked;
    // Start is called before the first frame update
    void Start()
    {
        overcooked = false;
        meat = GetComponent<CookedMeat>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Amount == 0 && !overcooked)
        {
            progressBar.sprite = progressBarOvercooked;
            backCooked.sprite = backOvercooked;

            overcooked = true;
            meat.Cooking();

            TimeReset();
        }
        else if (Amount == 0 && overcooked)
        {
            meat.OVercooking();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        //Debug.Log(meat.CookingTime);
        if (!overcooked)
            Decrease(meat.CookingTime);
        else
            Decrease(meat.OvercookingTime);
    }
}
