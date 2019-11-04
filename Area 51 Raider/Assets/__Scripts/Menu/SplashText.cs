using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplashText : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed;

    [SerializeField]
    private float baseOpacity;

    private TMP_Text tmpText;
    private float time = 1;

    void Awake()
    {
        // set text component (create if null, using null coalescing operator)
        tmpText = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        Color color = tmpText.color;
        // fade text alpha channel based on game time
        color.a = Mathf.Abs(Mathf.Cos(time * fadeSpeed)) * (1 - baseOpacity) + baseOpacity;
        tmpText.color = color;
        time += Time.deltaTime;
    }
}
