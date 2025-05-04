using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioClip BackGroundMisic;
    public AudioSource audioSource;
    public ScreenOffOn screenOffOn;

    private void Start()
    {
        audioSource.clip = BackGroundMisic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ChangeScene(int indexOfScene)
    {
        screenOffOn.FadeOut();
        SceneManager.LoadScene(indexOfScene);
    }

    public void ExitGame()
    {
        screenOffOn.FadeOut();
        Application.Quit();
    }
}
