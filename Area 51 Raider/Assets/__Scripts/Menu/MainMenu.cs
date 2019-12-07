using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(sceneName: "Level1");
    }

    public void OnTutorial()
    {
        SceneManager.LoadScene(sceneName: "Tutorial");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
