using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {
	
	private Player thePlayer;

	public Vector2 startDirection;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Player>();
		thePlayer.transform.position = transform.position;
		thePlayer.lastMove = startDirection;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
