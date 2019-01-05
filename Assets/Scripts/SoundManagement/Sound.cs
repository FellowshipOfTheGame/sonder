using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 10f)]    
    public float volume;

    [HideInInspector]
    public AudioSource source;
    
    public AudioMixerGroup output;
    public bool loop;

    public bool playOnAwake; 
}