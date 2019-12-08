using UnityEngine;

public class ResetOnStart : MonoBehaviour
{
    void Start()
    {
        // reset global game state
        GameState.ResetAll();
    }
}
