using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

	[SerializeField] private GameObject optionsMenu;
	private bool isOpen;
	private bool uiExists;
	private Player player;
	
	void Start()
	{
		if(!uiExists) //if player dont exists, dont destroy player on load
		{
			uiExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else // else detroy player;
		{
			Destroy(gameObject);
		}
		player = FindObjectOfType<Player>(); 
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && isOpen == false) //abre o menu
		{
			optionsMenu.SetActive(true);
			isOpen = true;
			player.disableMovement = true;
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && isOpen == true) // fecha o menu 
		{
			optionsMenu.SetActive(false);
			isOpen = false;
			player.disableMovement = false;
		}
	}
}
