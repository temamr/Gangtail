using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public List<Sprite> emotionsList;

    public void ChangeEmotion(int currentExpression)
    {
        Console.WriteLine(currentExpression);
        GetComponent<Image>().sprite = emotionsList[currentExpression];
    }
}
