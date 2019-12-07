using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    [SerializeField]
    private float hueInc = 0.5f;

    [SerializeField]
    private float scaleSpeed = 1;

    [SerializeField]
    private float scaleFactor = 0.02f;
    
    private float baseSize;

    private float hue = 0;
    private Color baseColor;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        baseColor = gameObject.GetComponent<Renderer>().material.color;
        baseSize = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        hue = (hue + hueInc * Time.deltaTime) % 1.0f;
        Color newColor = Color.HSVToRGB(hue, 1, 1);
        gameObject.GetComponent<Renderer>().material.color = newColor;

        float newSize = Mathf.Sin(time * scaleSpeed) * scaleFactor + baseSize;
        transform.localScale = new Vector3(newSize, newSize, 1);
        time += Time.deltaTime;
    }
}
