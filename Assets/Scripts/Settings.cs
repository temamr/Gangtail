using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Sprite audioOn;
    public Sprite audioOff;
    public Slider slider;
    public GameObject buttonAudio;
    private float lastSliderVolume;
    Resolution[] resolutions;
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        AudioListener.volume = savedVolume;
        slider.value = savedVolume;
        UpdateAudioButtonIcon();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.Save();
    }

    public void ExitSettings()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    //(Кнопка сохранить если понадобится полуавтоматическое сохранение)
    // public void SaveSettings()
    // {
    //     PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    //     PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    // }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
    }

    public void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();

        if (volume > 0)
        {
            lastSliderVolume = volume;
        }

        UpdateAudioButtonIcon();
    }

    public void OnOffAudio()
    {
        if(AudioListener.volume > 0)
        {
            lastSliderVolume = AudioListener.volume;
            AudioListener.volume = 0;
            slider.value = 0;
        }
        else
        {
            AudioListener.volume = lastSliderVolume;
            slider.value = lastSliderVolume;
        }

        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        PlayerPrefs.Save();

        UpdateAudioButtonIcon();
    }

    private void UpdateAudioButtonIcon()
    {
        buttonAudio.GetComponent<Image>().sprite = (AudioListener.volume > 0) ? audioOn : audioOff;
    }
}
