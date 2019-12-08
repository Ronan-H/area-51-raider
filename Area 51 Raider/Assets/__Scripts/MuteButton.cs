using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    // type of mute button ("sound" or "music")
    // settable through the editor
    [SerializeField]
    private string type;
    private bool toggled = false;

    private void Start()
    {
        // sound on by default
        GetComponent<Image>().color = Color.green;
    }

    public void OnClick()
    {
        // propogate event
        if (type.Equals("sound"))
        {
            GameObject.FindObjectOfType<SoundManager>().OnSoundMuteClicked();
        }
        else if (type.Equals("music"))
        {
            GameObject.FindObjectOfType<SoundManager>().OnMusicMuteClicked();
        }

        // toggle button
        toggled = !toggled;

        // update button colour (red = muted, green = not muted)
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
