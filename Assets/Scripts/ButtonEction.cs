using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonEction: MonoBehaviour
{
    public int index { get; set; }
    private Button button;
    private UnityAction clickAction;
    private Dialogue dialogue;
    void Start()
    {
        button = GetComponent<Button>();
        dialogue = FindObjectOfType<Dialogue>();
        clickAction = new UnityAction(() => dialogue.ChoiceButtonAction(index));
        button.onClick.AddListener(clickAction);
    }
}