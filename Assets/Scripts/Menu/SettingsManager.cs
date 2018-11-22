using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

	[SerializeField] private GameObject optionsMenu;
	private bool isOpen;
	private Player player;
	
	void Start()
	{
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
