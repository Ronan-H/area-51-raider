using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (!playerMovement.inBox)
            {
                playerMovement.EnterBox(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
