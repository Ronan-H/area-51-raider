using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameWin : MonoBehaviour
{
    // when the player touches the exit at the end of the level...
    private void OnTriggerEnter2D(Collider2D other)
    {
        // player wins if he has rescued the alien
        // (otherwise, the exit blocks the player from leaving the level)
        if (other.gameObject.tag == "Player" && GameState.FoundAlien)
        {
            SceneManager.LoadScene(sceneName: "YouWin");
        }
    }
}
