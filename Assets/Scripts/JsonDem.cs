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
		jsonString = File.ReadAllText(path);
		Dialogue dialogue = JsonUtility.FromJson<Dialogue>(jsonString);
		foreach( string sentences in dialogue.sentences)
			Debug.Log(sentences);
	}																																							
}