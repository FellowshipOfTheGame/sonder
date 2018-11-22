using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class teste : MonoBehaviour {
	public AudioSource audioSource;
	public bool play;
	private bool isRunning;
	// Use this for initialization
	void Start ()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isRunning == false && play == true)
		{
			isRunning = true;
			audioSource.Play();
		}
		else if(isRunning == true && play == false)
		{
			isRunning = false;
			audioSource.Pause();
		}
	}
}
