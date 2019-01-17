using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
	[SerializeField] private Dialogue dialogue; //phrases of the character
	private DialogueManager dMan; //dialogue Manager
	void Start () 
	{
		dMan = FindObjectOfType<DialogueManager>(); //get the dialog Manager in the scene 
	}
	void OnTriggerStay2D (Collider2D other) //talk to the npc
	{
		if(other.gameObject.name == "Player")  
		{
			if(Input.GetKeyDown(KeyCode.Z)) //the input of the player to talk to the character
			{	
				dMan.StartDialogue(dialogue); //start the dialogue of the player
			}
		}
	}
}
