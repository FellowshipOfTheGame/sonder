using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox; //dialog box
	public Text dText; //text inside the box 

	public bool dialogActive; //true if dialog is active

	public string[] dialogLines;
	public int currentLine;
	public Player thePlayer;


	// Use this for initialization
	void Start () 
	{
		thePlayer = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(dialogActive && Input.GetKeyDown(KeyCode.Z))
		{
			currentLine++;
		}
		if(currentLine >= dialogLines.Length)
		{
			dBox.SetActive(false);
			dialogActive = false;
			thePlayer.disableMovement = false;

			currentLine = 0;
		}

		dText.text = dialogLines[currentLine];
	
	}

	public void ShowBox(string dialogue)
	{
		dialogActive = true;
		thePlayer.disableMovement = true;
		dBox.SetActive(true);
		dText.text = dialogue;
	}

	public void ShowDialogue()
	{
		thePlayer.disableMovement = true;
		dialogActive = true;
		dBox.SetActive(true);
	}
	
}
