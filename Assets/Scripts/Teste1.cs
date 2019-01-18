using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste1 : MonoBehaviour {

	private Player thePlayer;

	void Start ()
	{
		thePlayer = FindObjectOfType<Player>(); //Find player in the scene7
	
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Z))
		{
			Debug.Log("ativado");
			FindObjectOfType<Alce>().teste = true;
		}
	}
}
