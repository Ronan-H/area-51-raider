using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BaDing;
    public AudioSource Siren;

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
}
