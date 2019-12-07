using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && GameState.FoundAlien)
        {
            SceneManager.LoadScene(sceneName: "YouWin");
        }
    }
}
