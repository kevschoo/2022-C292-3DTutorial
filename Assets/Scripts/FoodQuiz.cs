using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] RunTimeData _runtimedata;
    [SerializeField] Dialogue _dialogue;
    [SerializeField] Dialogue _FoodBoughtAlready;
    [SerializeField] Dialogue _FoodTooExpensive;
    [SerializeField] Dialogue _FoodBought;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameEvents.InvokeDialogueIntiated(_dialogue);
        }
       
    }

    public IEnumerator FoodSelected(GameObject food)
    {
        yield return new WaitForEndOfFrame();

        if(_runtimedata.CurrentFoodViewedisBought == false)
        {
            if (_runtimedata.CurrentCash >= _runtimedata.CurrentFoodViewedPrice)
            {
                GameEvents.InvokeDialogueIntiated(_FoodBought);
                food.GetComponent<Food>().setBought(true);
                _runtimedata.CurrentCash -= _runtimedata.CurrentFoodViewedPrice;
                _runtimedata.CurrentFood = _runtimedata.CurrentFoodViewed;
                _runtimedata.CurrentFoodDamage = _runtimedata.CurrentFoodViewedDamage;

            }
            else
            {
                GameEvents.InvokeDialogueIntiated(_FoodTooExpensive);
            }
        }
        else
        {
            GameEvents.InvokeDialogueIntiated(_FoodBoughtAlready);
            _runtimedata.CurrentFood = _runtimedata.CurrentFoodViewed;
            _runtimedata.CurrentFoodDamage = _runtimedata.CurrentFoodViewedDamage;
        }
        
    }
}
