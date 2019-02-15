using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardInteractable : DialogueHolder {

    protected override void TriggerDialogue()
    {
        dMan.StartDialogue(dialogueArray.dialogue[0],"");
    }
    protected override void EndDialogue()
	{
		
	}
}
