using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // player's movement speed
    private float speed;
    private Rigidbody2D rb2d;

    void Start()
    {
        speed = 40;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        // match boxcollider to sprite sizeq
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);

    }

    void FixedUpdate()
    {
        // get movement magnitudes
        float horizMag = Input.GetAxis("Horizontal");
        float verticalMag = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizMag, verticalMag);

        // check if the player is in a box
        bool inBox = gameObject.GetComponent<PlayerBox>().inBox;

        float trueSpeed = speed;
        // player moves slower if they're in a box
        if (inBox)
        {
            trueSpeed *= 0.7f;
        }
        // player moves faster if they have the running shoes item
        if (PlayerItems.HasItem("RunningShoes"))
        {
            trueSpeed *= 1.2f;
        }

        // move the player through rigidbody forces
        rb2d.AddForce(movement * trueSpeed);
    }
}
