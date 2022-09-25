using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodLabel : MonoBehaviour
{
    [SerializeField] RunTimeData _runtimedata;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = _runtimedata.CurrentFoodMouseOver;
        
    }
}
