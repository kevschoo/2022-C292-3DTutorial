using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEventArgs : EventArgs
{
    public Dialogue DialoguePayload;


}


public static class GameEvents 
{
    public static event EventHandler<DialogueEventArgs> DialogueIntiated;
    public static event EventHandler DialogueFinished;
    public static void InvokeDialogueIntiated(Dialogue dialog)
    {
        DialogueIntiated(null, new DialogueEventArgs {DialoguePayload = dialog });
    }

    public static void InvokeDialogueFinished()
    {
        DialogueFinished(null, EventArgs.Empty);
    }


}
