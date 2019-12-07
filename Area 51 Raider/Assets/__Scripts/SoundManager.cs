using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BaDing;
    public AudioSource Siren;

    public AudioSource StrangerThingsMusic;

    private bool soundMuted;

    void Start()
    {
        if (GameObject.FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        LoopStrangerThingsMusic();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBaDing()
    {
        BaDing.Play();
    }

    public void LoopSiren()
    {
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
        StrangerThingsMusic.mute = !StrangerThingsMusic.mute;
    }

    public void OnSoundMuteClicked()
    {
        BaDing.mute = !BaDing.mute;
        Siren.mute = !Siren.mute;
    }
}
