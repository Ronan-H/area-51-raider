using TMPro;
using UnityEngine;

public class SplashText : MonoBehaviour
{
    // allow setting of fade speed/base opacity through the editor
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
        // update text fade
        Color color = tmpText.color;
        color.a = Mathf.Abs(Mathf.Cos(time * fadeSpeed)) * (1 - baseOpacity) + baseOpacity;
        tmpText.color = color;
        time += Time.deltaTime;
    }
}
