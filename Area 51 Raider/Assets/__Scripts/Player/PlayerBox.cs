using UnityEngine;

// represents the player's interaction with boxes
public class PlayerBox : MonoBehaviour
{
    // true if the player is in a box
    // (public so it can be seen by GuardSearchlight)
    public bool inBox = false;

    // box prefab, so a box can be spawned when the player leaves the box
    [SerializeField]
    private GameObject boxPrefab;
    // player sprite to change to a box sprite when the player enters a box
    private Sprite playerSprite;

    // keep track of the jump button, to prevent the player from rapidly entering/exiting
    // a box when jump is held
    private bool jumpReleased;

    void Start()
    {
        // find player sprite
        playerSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        jumpReleased = false;
    }

    void Update()
    {
        if (inBox && !jumpReleased && !Input.GetButton("Jump"))
        {
            // player has released the jump button
            jumpReleased = true;
        }

        if (Input.GetButton("Jump") && inBox && jumpReleased)
        {
            // player wants to get out of the box

            // reset player sprite
            GetComponent<SpriteRenderer>().sprite = playerSprite;
            // spawn a box near the player (which moves in the opposite direction to the player,
            // to make is look like the player threw the box behind them when the left it)
            GameObject newBox = Instantiate(boxPrefab, gameObject.transform.position, gameObject.transform.rotation);
            newBox.GetComponent<Rigidbody2D>().velocity = -gameObject.GetComponent<Rigidbody2D>().velocity * 2;

            // reset vars
            inBox = false;
            jumpReleased = false;
        }
    }

    // called when the player should enter a box
    public void EnterBox(GameObject box)
    {
        // move player to box
        gameObject.transform.position = box.transform.position;
        // change player's sprite to a box sprite
        GetComponent<SpriteRenderer>().sprite = box.GetComponent<SpriteRenderer>().sprite;
        inBox = true;

        // (the box that the player enters is destroyed elsewhere after this method)
    }
}
