using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private static HashSet<string> items = new HashSet<string>();

    public static void Reset()
    {
        items = new HashSet<string>();
    }

    public static void AddItem(string itemName)
    {
        items.Add(itemName);

        if (itemName.StartsWith("Naruto"))
        {
            GameState.incScore();
        }
    }

    public static bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
