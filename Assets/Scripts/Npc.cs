using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

	// Update is called once per frame

	void OnTriggerStay2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{	
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
		}
	}
}
