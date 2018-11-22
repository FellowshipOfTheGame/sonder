using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	public string[] dialogueLines;
	private DialogueManager dMan;

	// Use this for initialization
	void Start () 
	{
		dMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerStay2D (Collider2D other)
	{
		
		if(other.gameObject.name == "Player")
		{
			if(Input.GetKeyUp(KeyCode.Z))
			{
				//dMan.ShowBox(dialogue);
				if(!dMan.dialogActive)
				{
					dMan.dialogLines = dialogueLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue();
				}
			}
		}
	}
}
