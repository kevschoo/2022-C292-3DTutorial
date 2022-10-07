using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New RunTimeData")]
public class RunTimeData : ScriptableObject
{
    //should just get the food object and get variables there but lazy
    public GameObject CurrentFoodViewed;

    public string CurrentFoodMouseOver;
    
    public int CurrentFoodViewedPrice;

    public int CurrentFoodViewedDamage;

    public bool CurrentFoodViewedisBought;



    public GameObject CurrentFood;

    public int CurrentFoodDamage;



    public GameplayState CurrentGameplayState;

    public int CurrentCash;

}
