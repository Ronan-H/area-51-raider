using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    // set of items the player has (just names, as string)
    private static HashSet<string> items = new HashSet<string>();

    public static void Reset()
    {
        // clear player's items
        items = new HashSet<string>();
    }

    public static void AddItem(string itemName)
    {
        // add item to set
        items.Add(itemName);

        if (itemName.StartsWith("Naruto"))
        {
            // score item; increment score
            GameState.incScore();
        }
    }

    // check if player has a certain item
    public static bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
