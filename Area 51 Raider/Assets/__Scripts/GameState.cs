using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool PlayerSeen { get; set; }
    public static bool FoundAlien { get; set; }
    private static int _score;

    public static void ResetAll()
    {
        PlayerSeen = false;
        GameObject.FindObjectOfType<SoundManager>().StopSiren();
    }

    public static void incScore()
    {
        _score++;
        GameObject.FindGameObjectWithTag("score").GetComponent<TMPro.TextMeshProUGUI>().text = "x " + _score;
    }
}
