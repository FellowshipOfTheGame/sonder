using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField]private Sound[] sounds;
	//private static AudioManager instance;
	private static bool audioManagerExists;
	void Start()
	{
		if(!audioManagerExists) //if audioManager dont exists, dont destroy audioManager on load
		{
			audioManagerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else // else detroy audioManager;
		{
			Destroy(gameObject);
		}
	}
	void Awake() { 
		// creates a AudioSource Component for each sound in the list, copying its atributes
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip  = s.clip;
			s.source.volume = s.volume;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = s.output;
			s.source.playOnAwake = s.playOnAwake;
		}
	}

	public void Play (string name)
	{
		foreach(Sound snd in sounds) // search for the sound in the sound array with the especified name
		{	
			if(snd.name.Equals(name))
			{
				//Debug.Log(snd.name);
				snd.source.Play();
				return;
			}
		}
		
		Debug.LogWarning("Sound: "+ name + " not found!");// if it cant be found;
	}
	
	public void Pause (string name)
	{
		foreach(Sound snd in sounds) // search for the sound in the sound array with the especified name
		{	
			if(snd.name.Equals(name))
			{
				Debug.Log(snd.name);
				snd.source.Pause();
				return;
			}
		}
		
		Debug.LogWarning("Sound: "+ name + " not found!");// if it cant be found;
	}
}
