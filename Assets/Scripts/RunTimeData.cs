using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New RunTimeData")]
public class RunTimeData : ScriptableObject
{
    public string CurrentFoodMouseOver;

    public GameplayState CurrentGameplayState;

}
