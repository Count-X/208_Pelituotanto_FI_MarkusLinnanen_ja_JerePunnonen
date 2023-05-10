using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource OtherAudioSource;
    public AudioSource MusicAudioSource;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        OtherAudioSource.clip = clip;
        OtherAudioSource.Play();
    }

    public void ChangeMusic(AudioClip clip) {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }
}
