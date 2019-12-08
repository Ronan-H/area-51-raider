using UnityEngine;

public class UIOverlay : MonoBehaviour
{
    void Start()
    {
        // destroy this overlay if one exists already
        if (GameObject.FindObjectsOfType<UIOverlay>().Length > 1)
        {
            Destroy(gameObject);
        }
        
        // there was no overlay; keep this overlay through scene changes
        DontDestroyOnLoad(gameObject);
    }
}
