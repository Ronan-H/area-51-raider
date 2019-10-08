using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);

    }

    void FixedUpdate()
    {
        float horizMag = Input.GetAxis("Horizontal");
        float verticalMag = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizMag, verticalMag);
        rb2d.AddForce(movement * speed);
    }
}
