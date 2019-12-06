using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb2d;
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
                float speed = Mathf.Abs(DistToPlayer() * 1.5f);
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (DistToPlayer() < 1.5f)
            {
                rescued = true;
                GameState.PlayerSeen = true;
                GameObject.FindObjectOfType<SoundManager>().LoopSiren();
            }
        }
    }

    private float DistToPlayer()
    {
        return Vector2.Distance(transform.position, playerTransform.position);
    }
}
