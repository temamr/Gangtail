using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public ScreenOffOn screenOffOn;
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
