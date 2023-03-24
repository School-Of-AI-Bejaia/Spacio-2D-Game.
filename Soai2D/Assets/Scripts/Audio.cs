using UnityEngine;

/// <summary>
/// CONTAINS 5:      name, audio clip, volume, pitch, loop, audio source
/// </summary>
[System.Serializable]
public class Audio 
{
    public enum AudioClipsNames
    {
        GamePlay,
        Bullet,
        Score,
        Asteroid
    }
    
    
    public AudioClipsNames name;
    public AudioClip clip;
    [Range(0f,1f)]       // to make sliders for our volume & pitch in the inspector
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
