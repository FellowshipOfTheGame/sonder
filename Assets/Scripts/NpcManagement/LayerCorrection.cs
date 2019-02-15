using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCorrection : MonoBehaviour {

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

