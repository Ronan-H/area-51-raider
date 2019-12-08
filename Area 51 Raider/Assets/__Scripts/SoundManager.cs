using UnityEngine;

// script for playing sounds or music
public class SoundManager : MonoBehaviour
{
    // sound effects
    public AudioSource BaDing;
    public AudioSource Siren;

    // music
    public AudioSource StrangerThingsMusic;

    void Start()
    {
        // destroy this sound manager if one exists already
        if (GameObject.FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        // there was no sound manager; keep this sound manager through scene changes
        DontDestroyOnLoad(gameObject);

        // loop music
        LoopStrangerThingsMusic();
    }

    public void PlayBaDing()
    {
        BaDing.Play();
    }

    public void LoopSiren()
    {
        // only loop if not already looping
        if (!Siren.isPlaying)
        {
            Siren.loop = true;
            Siren.Play();
        }
    }

    public void StopSiren()
    {
        Siren.Stop();
    }

    public void LoopStrangerThingsMusic()
    {
        // only loop if not already looping
        if (!StrangerThingsMusic.isPlaying)
        {
            StrangerThingsMusic.loop = true;
            StrangerThingsMusic.Play();
        }
    }

    public void StopStrangerThingsMusic()
    {
        StrangerThingsMusic.Stop();
    }

    public void OnMusicMuteClicked()
    {
        // toggle music mute
        StrangerThingsMusic.mute = !StrangerThingsMusic.mute;
    }

    public void OnSoundMuteClicked()
    {
        // toggle sound mute
        BaDing.mute = !BaDing.mute;
        Siren.mute = !Siren.mute;
    }
}
