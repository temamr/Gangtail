using System;
using System.Linq;
using TMPro;
using TMPro.Examples;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeNameScene : MonoBehaviour
{
    public AudioClip BackGroundMisic;
    public AudioSource audioSource;
    public ScreenOffOn screenOffOn;
    public TextMeshProUGUI Input;
    public Image ExeptionImage;
    public TextMeshProUGUI saveTextButtonText;

    private void Start()
    {
        saveTextButtonText.text = "Продолжить";
        ExeptionImage.enabled = false;
        if (GameData.PlayerName.Length > 0)
            Input.text = GameData.PlayerName;
        audioSource.clip = BackGroundMisic;
        audioSource.loop = true;
        audioSource.Play();
    }
    
    public void SaveName()
    {
        if (Input.text.Length == 1)
        {
            ExeptionImage.enabled = true;
            return;
        }
        
        GameData.PlayerName = Input.text;
        ChangeScene(10);
    }

    public void ChangeScene(int indexOfScene)
    {
        screenOffOn.FadeOut();
        SceneManager.LoadScene(indexOfScene);
    }
}