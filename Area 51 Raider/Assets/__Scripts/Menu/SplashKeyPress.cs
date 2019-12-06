using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashKeyPress : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // wait for any key press
        // (ignoring mouse clicks)
        if (Input.anyKeyDown && !(
           Input.GetMouseButtonDown(0)
        || Input.GetMouseButtonDown(1)
        || Input.GetMouseButtonDown(2)))
        {
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
    }
}
