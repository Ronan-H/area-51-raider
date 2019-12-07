using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField]
    private string type;
    private bool toggled = false;

    private void Start()
    {
        GetComponent<Image>().color = Color.green;
    }

    public void OnClick()
    {
        if (type.Equals("sound"))
        {
            GameObject.FindObjectOfType<SoundManager>().OnSoundMuteClicked();
        }
        else if (type.Equals("music"))
        {
            GameObject.FindObjectOfType<SoundManager>().OnMusicMuteClicked();
        }

        toggled = !toggled;

        if (toggled)
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
        }
    }
}
