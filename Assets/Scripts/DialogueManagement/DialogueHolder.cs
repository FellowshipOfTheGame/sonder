using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class DialogueHolder : MonoBehaviour {
	[SerializeField] protected DialogueArray dialogueArray; //phrases of the character

	protected DialogueManager dMan; //dialogue Manager
	
	[SerializeField] protected string npcName;

	void Start () 
	{
		dMan = FindObjectOfType<DialogueManager>(); //get the dialog Manager in the scene
		LoadDialogue();
	}

	void Update()
	{
		if(dMan.endDialogueActive)
		{
			dMan.endDialogueActive = false;
			EndDialogue();
		}
	}

	void LoadDialogue()
	{
		string path = Application.streamingAssetsPath +"/" + npcName + ".json";
		Debug.Log(path);
		string jsonString = File.ReadAllText(path);
		dialogueArray = JsonUtility.FromJson<DialogueArray>(jsonString);
		foreach( Dialogue d in dialogueArray.dialogue)
		{
			foreach( string sentence in d.sentences)
			Debug.Log(sentence);
		}
	}
	void OnTriggerStay2D (Collider2D other) //talk to the npc
	{
		if(other.gameObject.name == "Player")  
		{	
			if(Input.GetKeyDown(KeyCode.Z)) //the input of the player to talk to the character
			{	
				TriggerDialogue();
			}
		}
	}
	protected abstract void TriggerDialogue();

	protected abstract void EndDialogue();
}
