using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Alce : DialogueHolder {

	public bool teste;
	string path;
	string jsonString;
	void Start()
	{
		path = Application.streamingAssetsPath + "/alce.json";
		jsonString = File.ReadAllText(path);
		dialogue  = JsonUtility.FromJson<Dialogue[]>(jsonString);
	}
	protected override void TriggerDialogue()
	{
		if(teste)
			dMan.StartDialogue(dialogue[1]);
		else
		 	dMan.StartDialogue(dialogue[0]);
	}
}
