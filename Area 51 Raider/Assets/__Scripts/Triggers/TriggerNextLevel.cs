using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextLevel : MonoBehaviour
{
    // name of scene to load when the player touches this gameobject
    [SerializeField]
    private string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // player touched trigger, load next level
            SceneManager.LoadScene(sceneName: sceneName);
        }
    }
}
