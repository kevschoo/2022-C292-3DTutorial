using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] RunTimeData _runetimedata;
    [SerializeField] Dialogue _startingDialogue;

    // Start is called before the first frame update
    void Awake()
    {
        _runetimedata.CurrentGameplayState = GameplayState.InDialogue;
        _runetimedata.CurrentFoodMouseOver = "";
        
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
