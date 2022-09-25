using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] Dialogue _dialogue;
    [SerializeField] Dialogue _correctDialogue;
    [SerializeField] Dialogue _incorrectDialogue;

    [SerializeField] GameObject _CorrectFood;


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
        GameEvents.InvokeDialogueIntiated(_dialogue);
    }

    public IEnumerator FoodSelected(GameObject food)
    {
        yield return new WaitForEndOfFrame();

        if (food == _CorrectFood)
        {
            GameEvents.InvokeDialogueIntiated(_correctDialogue);
        }
        else
        {
            GameEvents.InvokeDialogueIntiated(_incorrectDialogue);
        }

        Destroy(food);
    }
}
