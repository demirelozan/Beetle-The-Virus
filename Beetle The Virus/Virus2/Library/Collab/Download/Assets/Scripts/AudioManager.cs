
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] audioSources;
    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void Play(int index)
    {
        // Sound s=  Array.Find(sounds, sound => sound.name == name);
        audioSources[index].Play();
    }
}
