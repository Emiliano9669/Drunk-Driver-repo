using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource music;
    public AudioLowPassFilter audioFilter;

    public static MusicManager musicManagerInstance;

    void Awake()
    {
        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
            DontDestroyOnLoad(this);
            print("music mangaer assigned");
        }
        else
        {
            Destroy(this);
            print("music manager destroyed");
        }
    }

    void Start()
    {
        if (!music.isPlaying)
            music.Play();
    }


    public void ActivateLowFrequencyAudio()
    {
        audioFilter.cutoffFrequency = 500;
    }

    public void NoFilterForAudio()
    {
        audioFilter.cutoffFrequency = 22000;
    }

}
