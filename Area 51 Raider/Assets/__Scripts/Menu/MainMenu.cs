﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(sceneName: "Level1");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
