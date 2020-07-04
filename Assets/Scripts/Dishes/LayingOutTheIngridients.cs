using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingOutTheIngridients : MonoBehaviour
{
    [SerializeField] private CookingController cookingController;
    [SerializeField] GameObject IngridientBrefab;
    [SerializeField] GameObject[] boardsOrPans;
    [SerializeField] GameObject[] ingridient;
    // Start is called before the first frame update
    void Start()
    {
        ingridient = new GameObject[boardsOrPans.Length];
    }
    public void OnMouseDown()
    {
        for (int i = 0; i < boardsOrPans.Length; i++)
        {
            if (ingridient[i] == null)
            {
                ingridient[i] = Instantiate(IngridientBrefab, boardsOrPans[i].transform.position, Quaternion.identity, boardsOrPans[i].transform);
                ingridient[i].GetComponent<CookedMeat>().cookingController = cookingController;

                Debug.Log("Add Ingridient");
                return;
            }
        }
        Debug.Log("All Boards Or Pan Full");
    }
}
