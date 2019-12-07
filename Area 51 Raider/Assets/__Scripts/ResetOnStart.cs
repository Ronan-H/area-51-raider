using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameState.ResetAll();
    }
}
