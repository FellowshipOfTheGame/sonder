using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alce : DialogueHolder {

	public bool teste;

	[SerializeField] private Text line;

	[SerializeField] private Lyrics[] music;	
	
	protected override void TriggerDialogue()
	{
		if(teste)
			dMan.StartDialogue(dialogue[1]);
		else
		 	dMan.StartDialogue(dialogue[0]);
	}

	protected override void EndDialogue()
	{
		StartCoroutine(Teste());
	}

	IEnumerator Teste()
	{
		line.gameObject.SetActive(true);
		foreach (Lyrics verse in music)
		{
			line.text = verse.lyric;
			yield return new WaitForSeconds(verse.delay);
		}
		line.text = "";
		line.gameObject.SetActive(false);
	}
}
