using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterBox : MonoBehaviour
{
    private bool jumpReleased = false;

    private void Update()
    {
        if (!jumpReleased && !Input.GetButton("Jump"))
        {
            jumpReleased = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButton("Jump") && jumpReleased)
        {
            PlayerBox playerBox = other.gameObject.GetComponent<PlayerBox>();
            if (!playerBox.inBox)
            {
                playerBox.EnterBox(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
