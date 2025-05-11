using System;
using System.Linq;
using TMPro;
using TMPro.Examples;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipScene : MonoBehaviour
{
    public void ChangeScene(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene);
    }
}
