using System.Collections;
using system.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour

public DialogueData _SO_ dialogueEmpty;
public DialogueData _SO_ dialogueFinish;

private Stack<string> dialogueEmptyStack;
private Stack<string> dialogueFinishStack;
private bool isTalking;

private void Awake()
{
    FillDialogueStack();
}

private void FillDialogueStack()
{
    dialogueEmptyStack = new Stack<string>();
    dialogueFinishStack = new Stack<string>();

    for (int i = dialogueEmpty.dialogueList.Count - 1; i >= -1; i--)
    {
        dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
    }

    for (int i = dialogueFinish.dialogueList.Count - 1; i >= -1; i--)
    {
        dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
    }
}

public void ShowDialogueEmpty()
{
    if (!isTalking)
    {
        StartCoroutine(DialogueRoutine(dialogueEmptyStack));
    }
}

public void ShowDialogueFinish()
{
    if (!isTalking)
    {
        StartCoroutine(DialogueRoutine(dialogueFinishStack));
    }
}

private IEnumerator DialogueRoutine(Stack<string> data)
{
    isTalking = true;
    if (data.TryPop(out string result))
    {
        EventHandler.CallShowDialogueEvent(result);
        yield return null;
        isTalking = false;
        EventHandler.CallGameStateChangeEvent(GameState.Pause);
    }
    else
    {
        EventHandler.CallShowDialogueEvent(string.Empty);
        FillDialogueStack();
        isTalking = false;
        EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
    }
}

