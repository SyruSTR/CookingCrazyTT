using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingBread : MonoBehaviour
{
    [SerializeField] CookingController.Meats meat;
    [SerializeField] CookingController cookingContr;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        cookingContr.AddDish(meat);
    }
}
