using System;
using Unity.VisualScripting;using UnityEngine;
public class MusicPlayer : MonoBehaviour
{
    private int indexOfPlayingMusic = -1;
        
    public AudioClip[] BackGroundMusick;
    public AudioSource audioSource;

    public void PlayMusic(int index, bool needLoop = false)
    {
        if (indexOfPlayingMusic == index)
            return;
        indexOfPlayingMusic = index;
        if (indexOfPlayingMusic == -1)
        {
            StopMusic();
            return;
        }
        
        audioSource.clip = BackGroundMusick[index];
        audioSource.loop = needLoop; 
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
