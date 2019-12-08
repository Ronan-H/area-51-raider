using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashKeyPress : MonoBehaviour
{
    void Update()
    {
        // wait for any key press
        // (ignoring mouse clicks)
        if (Input.anyKeyDown && !(
           Input.GetMouseButtonDown(0)
        || Input.GetMouseButtonDown(1)
        || Input.GetMouseButtonDown(2)))
        {
            // load main menu
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
    }
}
