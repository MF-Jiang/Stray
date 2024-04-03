using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class Cody : Interactive
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if (isDone)
        {
            dialogueController.ShowDialogueFinish();
        }
        else
        {
            //对话内容A
            dialogueController.ShowDialogueEmpty();
        }
    }

    protected override void OnClickedAction()
    {
        //对话内容B
        dialogueController.ShowDialogueFinish();
    }
}
