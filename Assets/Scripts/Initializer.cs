using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] RunTimeData _runtimedata;
    [SerializeField] Dialogue _startingDialogue;
    [SerializeField] int _startfoodDamage;
    [SerializeField] int _startcash;
    [SerializeField] GameObject _startFood;

    // Start is called before the first frame update
    void Awake()
    {
        _runtimedata.CurrentGameplayState = GameplayState.InDialogue;
        _runtimedata.CurrentFoodMouseOver = "";
        _runtimedata.CurrentFoodViewed = null;

        _runtimedata.CurrentFoodMouseOver = null;

        _runtimedata.CurrentFoodViewedPrice = 0;

        _runtimedata.CurrentFoodViewedDamage = 0;

        _runtimedata.CurrentFoodViewedisBought = false;

        _runtimedata.CurrentFood = _startFood;


        _runtimedata.CurrentFoodDamage = _startfoodDamage;


        _runtimedata.CurrentCash = _startcash;

}

    private void Start()
    {
        GameEvents.InvokeDialogueIntiated(_startingDialogue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
