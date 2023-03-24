using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField]private Audio[] audios;
    
    public static AudioManager Instance => instance;
    
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Initialize each audio in the game
        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();   // set audio source for each audio
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }
    }


    public void Play(Audio.AudioClipsNames name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);    // Search audio by name

        if (a == null)
        {
            Debug.Log("Audio " + name + " not found");
            return;
        }     

        // a.source.PlayOneShot(a.clip);
        a.source.Play();
    }

    
    public void Stop(Audio.AudioClipsNames name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);    // Search by name
        if (a == null)
            return;
        a.source.Stop();
    }
}
