using UnityEngine;

// keeps track of global game state
public class GameState : MonoBehaviour
{
    // true if the player has been spotted by a guard
    public static bool PlayerSeen { get; set; }
    // true if the player has found the alien in the final level
    public static bool FoundAlien { get; set; }
    // player's score
    private static int _score;

    // reset global game state
    public static void ResetAll()
    {
        PlayerSeen = false;
        GameObject.FindObjectOfType<SoundManager>().StopSiren();
    }
    
    // increments player's score by 1
    public static void incScore()
    {
        _score++;
        // update score text on UI
        GameObject.FindGameObjectWithTag("score").GetComponent<TMPro.TextMeshProUGUI>().text = "x " + _score;
    }
}
