using System;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.Threading.Tasks;
using Zenject;
using TextAsset = UnityEngine.TextAsset;


public class Dialogue: MonoBehaviour
{
    public Image DialogueNameImage;
    
    public AudioClip BackGroundMisic;
    public AudioSource audioSource;
    private bool isPrinting;
    
    public GameObject KunitsaCharacter;
    public GameObject TurtleCharacter;
    public MusicPlayer Music;
    
    public int indexOfNextScene;
    private Story currentStory;
    private TextAsset inkJson;
    
    private GameObject dialoguePanel;
    private TextMeshProUGUI dialogueText;
    private TextMeshProUGUI nameText;

    [HideInInspector] public GameObject choiceButtonPanel;
    private GameObject choiceButton;
    private List<TextMeshProUGUI> choiceTextList = new List<TextMeshProUGUI>();

    private ScreenOffOn screenOffOn;
    
    [Inject]
    public void Construct(DialoguesInstaller dialoguesInstaller)
    {
        inkJson = dialoguesInstaller.inkJson;
        dialoguePanel = dialoguesInstaller.dialoguePanel;
        dialogueText = dialoguesInstaller.dialogueText;
        nameText = dialoguesInstaller.nameText;
        choiceButtonPanel = dialoguesInstaller.buttonPanel;
        choiceButton = dialoguesInstaller.chosenButton;
        screenOffOn = dialoguesInstaller.screenOffOn;
    }
    public bool DialoguePlay { get; private set; }

    private void Awake()
    {
        currentStory = new Story(inkJson.text);
    }

    private void Start()
    {
        audioSource.clip = BackGroundMisic;
        audioSource.loop = true;
        audioSource.Play();
        screenOffOn.FadeIn();
        StartDialogue();
    }

    public void StartDialogue()
    {
        DialoguePlay = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    public void ContinueStory(bool choiceBefore = false)
    {
        if (!isPrinting && currentStory.canContinue)
        {
            ShowDialogue();
            ShowChoiceButtons();
        }
        else if (!choiceBefore && !isPrinting)
        {
            ExitDialogue();
        }
    }

    private void UpdateMusic()
    {
        var indexOfMusic = (int)currentStory.variablesState["Music"];
        Music.PlayMusic(indexOfMusic);
        
    }
    
    private void UpdateCharacter()
    {
        var kunitsa = KunitsaCharacter.GetComponent<Character>();
        var indexOfKunitsaEmotion = (int)currentStory.variablesState["KunitsaEmotion"];
        kunitsa.ChangeEmotion(indexOfKunitsaEmotion);
        
        var turtle = TurtleCharacter.GetComponent<Character>();
        var indexOfEmotion = (int)currentStory.variablesState["TurtleEmotion"];
        turtle.ChangeEmotion(indexOfEmotion);
    }
    
    async void PrintText(string text)
    {
        if (isPrinting) return; // Игнорируем новый вызов
    
        isPrinting = true;
        dialogueText.text = "";
    
        foreach (var i in text)
        {
            dialogueText.text += i;
            await Task.Delay(20);
        }
    
        isPrinting = false;
    }
    
    private void ShowDialogue()
    {
        if (!isPrinting)
        {
            DialogueNameImage.enabled = true;
            PrintText(currentStory.Continue());
            nameText.text = (string)currentStory.variablesState["CharacterName"];
            if (nameText.text == "")
                DialogueNameImage.enabled = false;
            UpdateCharacter();
            UpdateMusic();
        }
    }

    private void ShowChoiceButtons()
    {
        var currentChoices = currentStory.currentChoices;
        choiceButtonPanel.SetActive(currentChoices.Count != 0);
        if (currentChoices.Count <= 0)
            return;

        for (var i = 0; i < currentChoices.Count; i++)
        {
            var choice = Instantiate(choiceButton);
            choice.GetComponent<ButtonEction>().index = i;
            choice.transform.SetParent(choiceButtonPanel.transform);

            var choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = currentChoices[i].text;
            choiceTextList.Add(choiceText);
        }
    }

    public void ChoiceButtonAction(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void ExitDialogue()
    {
        screenOffOn.FadeOut();
        DialoguePlay = false;
        SceneManager.LoadScene(indexOfNextScene);
    }
}