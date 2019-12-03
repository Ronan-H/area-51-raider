using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BaDing;
    public AudioSource Siren;

    public AudioSource StrangerThingsMusic;

    void Start()
    {
        LoopStrangerThingsMusic();
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
            //StrangerThingsMusic.loop = true;
            //StrangerThingsMusic.Play();
        }
    }

    public void StopStrangerThingsMusic()
    {
        StrangerThingsMusic.Stop();
    }
}
