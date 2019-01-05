using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private string volumeLabel;

	public void setVolume(float volume)
	{
		audioMixer.SetFloat(volumeLabel, volume);
	}
	
}
