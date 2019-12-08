using UnityEngine;

public class TriggerItemPickup : MonoBehaviour
{
    // allow setting of item name through the editor
    [SerializeField]
    private string itemName;

    private void Start()
    {
        if (PlayerItems.HasItem(itemName))
        {
            // player already has this item, destroy it
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // give this item to the player
            PlayerItems.AddItem(itemName);
            // play the item pickup sound effect
            GameObject.FindObjectOfType<SoundManager>().PlayBaDing();
            // destory this item
            Destroy(gameObject);
        }
    }
}
