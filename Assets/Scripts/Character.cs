using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public List<Sprite> emotionsList;
    private float increaseCoeff = 1.05f;
    private Vector3 defultSize;

    public void Start()
    {
        defultSize = transform.localScale;
    }

    public void ChangeEmotion(int currentExpression)
    {
        Console.WriteLine(currentExpression);
        GetComponent<Image>().sprite = emotionsList[currentExpression];
    }

    public void IncreaseSize()
    {
        if (transform.localScale.x < defultSize.x * 1.3)
            transform.localScale *= increaseCoeff;
    }

    public void NormalizeSize()
    {
        transform.localScale = defultSize;
    }
}
