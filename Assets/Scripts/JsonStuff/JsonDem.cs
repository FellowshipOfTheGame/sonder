using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;

public class JsonDem : MonoBehaviour {
	string path;
	string jsonString;

	void Start()
	{
		path = Application.streamingAssetsPath + "/alce.json";
		Debug.Log(path);
		jsonString = File.ReadAllText(path);
		DialogueArray dialog = JsonUtility.FromJson<DialogueArray>(jsonString);
		foreach( Dialogue d in dialog.dialogue)
		{
			foreach( string sentence in d.sentences)
			Debug.Log(sentence);
		}
	}																																							
}