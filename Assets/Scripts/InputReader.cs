using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IDialogueActions
{
    private Controls inputAction;
    private Dialogue dialogue;

    private void OnEnable()
    {
        dialogue = FindObjectOfType<Dialogue>();
        if (inputAction != null)
            return;
        inputAction = new Controls();
        inputAction.Dialogue.SetCallbacks(this);
        inputAction.Dialogue.Enable();
    }

    private void OnDisable()
    {
        inputAction.Dialogue.Disable();
    }

    public void OnNextPhrase(InputAction.CallbackContext context)
    {
        if (context.started && dialogue.DialoguePlay)
        {
            dialogue.ContinueStory(dialogue.choiceButtonPanel.activeInHierarchy);
        }
    }
}