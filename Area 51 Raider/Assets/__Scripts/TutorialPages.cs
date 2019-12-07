using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPages : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pages;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    public void Next()
    {
        if (index == pages.Length - 1)
        {
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
        else
        {
            pages[index].SetActive(false);
            pages[++index].SetActive(true);
        }
    }
}
