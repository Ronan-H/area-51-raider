using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // on play button clicked...
    public void OnPlay()
    {
        // load level 1
        SceneManager.LoadScene(sceneName: "Level1");
    }

    // on tutorial button clicked...
    public void OnTutorial()
    {
        // load tutorial
        SceneManager.LoadScene(sceneName: "Tutorial");
    }
    
    // on quit button clicked...
    public void OnQuit()
    {
        // exit the application
        Application.Quit();
    }
}
