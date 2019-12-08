using UnityEngine;

// script attached to boxes to detect when the player wants to enter them
public class TriggerEnterBox : MonoBehaviour
{
    // keep track of the jump button, to prevent the player from rapidly entering/exiting
    // a box when jump is held
    private bool jumpReleased = false;

    private void Update()
    {
        if (!jumpReleased && !Input.GetButton("Jump"))
        {
            // player has released the jump button
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
                // player wants to enter the box
                playerBox.EnterBox(gameObject);
                // destroy this box
                Destroy(gameObject);
            }
        }
    }
}
