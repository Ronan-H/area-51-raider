using UnityEngine;

// visual effects for items that the player can pick up
// (rainbow colour and scaling)
public class ItemEffect : MonoBehaviour
{
    // speed of hue change
    // settable through the editor
    [SerializeField]
    private float hueInc = 0.5f;
    // hue value (updated over time)
    private float hue = 0;

    // speed of scaling change
    // settable through the editor
    [SerializeField]
    private float scaleSpeed = 1;
    // how much the item should scale bigger/smaller
    // settable through the editor
    [SerializeField]
    private float scaleFactor = 0.02f;
    // normal size of this item before scaling
    private float baseSize;
    
    void Start()
    {
        // set base size
        baseSize = gameObject.transform.localScale.x;
    }
    
    // update item effect
    void Update()
    {
        // update hue (to make a rainbow pattern)
        hue = (hue + hueInc * Time.deltaTime) % 1.0f;
        Color newColor = Color.HSVToRGB(hue, 1, 1);
        gameObject.GetComponent<Renderer>().material.color = newColor;

        // update scale (so the item gets bigger and smaller over time)
        float newSize = Mathf.Sin(Time.time) * scaleFactor + baseSize;
        transform.localScale = new Vector3(newSize, newSize, 1);
    }
}
