using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    public bool inBox = false;

    [SerializeField]
    private GameObject boxPrefab;
    private Sprite playerSprite;

    private bool jumpReleased;

    void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        jumpReleased = false;
    }

    void Update()
    {
        if (inBox && !jumpReleased && !Input.GetButton("Jump"))
        {
            jumpReleased = true;
        }

        if (Input.GetButton("Jump") && inBox && jumpReleased)
        {
            GetComponent<SpriteRenderer>().sprite = playerSprite;
            GameObject newBox = Instantiate(boxPrefab, gameObject.transform.position, gameObject.transform.rotation);
            newBox.GetComponent<Rigidbody2D>().velocity = -gameObject.GetComponent<Rigidbody2D>().velocity * 2;
            inBox = false;
            jumpReleased = false;
        }
    }

    public void EnterBox(GameObject box)
    {
        gameObject.transform.position = box.transform.position;
        GetComponent<SpriteRenderer>().sprite = box.GetComponent<SpriteRenderer>().sprite;
        inBox = true;
    }
}
