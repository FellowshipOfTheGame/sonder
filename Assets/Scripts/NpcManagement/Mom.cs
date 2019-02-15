using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : DialogueHolder
{
	public static bool firstDialogue = true;
    protected override void TriggerDialogue()
	{
		if(firstDialogue)
		{
			dMan.StartDialogue(dialogueArray.dialogue[0], npcName + " :");
			firstDialogue = false;
		}
		else
		 	dMan.StartDialogue(dialogueArray.dialogue[1], npcName + " :");
	}

    protected override void EndDialogue()
	{
		
	}
}
