using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOffOn: MonoBehaviour
{
    public Image fadeImage;
    private float fadeDuration = 1f;
    
    public void FadeIn()
    {
        StartCoroutine(FadeRoutine(1f, 0f));
    }
    
    public void FadeOut()
    {
        StartCoroutine(FadeRoutine(0f, 1f));
    }
    
    private IEnumerator<string> FadeRoutine(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime / 2;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        
        color.a = targetAlpha;
        fadeImage.color = color;
    }
}