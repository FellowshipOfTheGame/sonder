using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardInteractable : DialogueHolder {

    protected override void TriggerDialogue()
    {
        dMan.StartDialogue(dialogue[0]);
    }
    protected override void EndDialogue()
	{
		
	}
}
