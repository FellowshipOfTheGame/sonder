using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour 
{

	[SerializeField] private Button playB; 
	[SerializeField] string levelToLoad;

	void Start()
	{
		playB.onClick.AddListener(PlayOnClick);
	}
	void PlayOnClick()
	{
		SceneManager.LoadScene(levelToLoad); //load the new scene
	}
}
