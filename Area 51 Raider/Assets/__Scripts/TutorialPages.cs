using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPages : MonoBehaviour
{
    // tutorial pages, settable from the editor
    [SerializeField]
    private GameObject[] pages;
    // index of the page that's currently showing
    private int index;
    
    void Start()
    {
        index = 0;
    }

    public void Next()
    {
        if (index == pages.Length - 1)
        {
            // no more pages, go back to main menu
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
        else
        {
            // hide the current page, show the next page
            pages[index].SetActive(false);
            pages[++index].SetActive(true);
        }
    }
}
