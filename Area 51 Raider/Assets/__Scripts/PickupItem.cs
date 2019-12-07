using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    private void Start()
    {
        if (PlayerItems.HasItem(itemName))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerItems.AddItem(itemName);
            GameObject.FindObjectOfType<SoundManager>().PlayBaDing();
            Destroy(gameObject);
        }
    }
}
