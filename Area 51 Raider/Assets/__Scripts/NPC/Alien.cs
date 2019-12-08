using UnityEngine;

public class Alien : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb2d;
    // true if the player has rescued this alien
    private bool rescued = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rescued)
        {
            if (DistToPlayer() > 1f)
            {
                // move towards player (quicker if further away, alien shouldn't fall behind too much)
                float speed = Mathf.Abs(DistToPlayer() * 1.5f);
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (DistToPlayer() < 4f)
            {
                // player is close enough to rescue this alien
                rescued = true;
                // update global game state
                GameState.PlayerSeen = true;
                GameState.FoundAlien = true;
                // loop the siren sound effect
                GameObject.FindObjectOfType<SoundManager>().LoopSiren();
                // enable the end game trigger (where the exit is)
                GameObject.FindGameObjectWithTag("Finish").GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private float DistToPlayer()
    {
        return Vector2.Distance(transform.position, playerTransform.position);
    }
}
