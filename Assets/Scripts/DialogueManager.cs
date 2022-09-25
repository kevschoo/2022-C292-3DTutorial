using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue _CurrentDialogue;
    [SerializeField] int _CurrentSlide = 0;
    [SerializeField] RunTimeData _runtimedata;

    void Awake()
    {
        GameEvents.DialogueFinished += OnDialogueFinish;
        GameEvents.DialogueIntiated += OnDialogueIntiate;
    }



        // Start is called before the first frame update
        void Start()
    {
        _runtimedata.CurrentGameplayState = GameplayState.InDialogue;
        ShowSlide();
        LoadAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_CurrentSlide < _CurrentDialogue.DialogSlides.Length - 1)
            {
                _CurrentSlide++;
                ShowSlide();
            }

            else
            {
                GameEvents.InvokeDialogueFinished();
            }
        }
    }


    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogueText").gameObject;
        TextMeshProUGUI textComp = textObj.GetComponent<TextMeshProUGUI>();
        textComp.text = _CurrentDialogue.DialogSlides[_CurrentSlide];
    }

    void LoadAvatar()
    {
        GameObject avatarObj = transform.Find("Face").gameObject;
        avatarObj.GetComponent<RawImage>().texture = _CurrentDialogue.NPCFace;
    }

    void OnDialogueFinish(object Sender, EventArgs args)
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        _runtimedata.CurrentGameplayState = GameplayState.FreeWalk;
    }

    void OnDialogueIntiate(object Sender, DialogueEventArgs args)
    {
        _CurrentDialogue = args.DialoguePayload;
        _CurrentSlide = 0;
        LoadAvatar();
        ShowSlide();
        gameObject.GetComponent<Canvas>().enabled = true;
        _runtimedata.CurrentGameplayState = GameplayState.InDialogue;
    }

}
