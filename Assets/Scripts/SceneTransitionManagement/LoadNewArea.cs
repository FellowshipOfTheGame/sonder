using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {
	[SerializeField]private string levelToLoad;  //name of the scene that will be loaded
	private Player thePlayer; 
	[SerializeField]private Vector3 startPoint; //position of the startpoint in the new scene
	[SerializeField]private Vector2 startDirection; //direction where the player should be facing
	[SerializeField]private Animator transitionAnim;


	// Use this for initialization
	void Start ()
	{
		thePlayer = FindObjectOfType<Player>(); //gets the player;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) //when a object with a component of the collider2D enter the collider zone, trigger this function
	{
		if(other.gameObject.name == "Player") //if the gameObeject that has entered the zone is the player
		{
			StartCoroutine(LoadScene());
		}
	}

	private IEnumerator LoadScene()
	{
		thePlayer.disableMovement = true;
		transitionAnim.SetTrigger("end");
		FindObjectOfType<AudioManager>().Play("door");
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene(levelToLoad); //load the new scene
		thePlayer = FindObjectOfType<Player>();
		thePlayer.disableMovement = true;
		thePlayer.transform.position = startPoint; //set its position to the start point of the new scene
		thePlayer.lastMove = startDirection; // set the direction the player faces
		thePlayer.disableMovement = false;
	}
}
