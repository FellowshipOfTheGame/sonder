using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RandomEncounter : MonoBehaviour {
	private Player thePlayer;
	private bool couritineRunning;
	[SerializeField]private Animator transitionAnim;
	[SerializeField]private string levelToLoad;  //name of the scene that will be loaded
    // Use this for initialization
    void Start ()
	{
		thePlayer = FindObjectOfType<Player>();
		thePlayer.GetComponent<SpriteRenderer>().enabled = true;
		thePlayer.disableMovement = false;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{	
		if(!couritineRunning) // waits until the actual courotineRunning ends
			StartCoroutine(loadBattle(other));
	}

	private IEnumerator loadBattle(Collider2D other)
	{	
		if(other.gameObject.name == "Player" && thePlayer.playerMoving)
		{		
				couritineRunning = true;
				int random = Random.Range(0, 10); //generate random number
				Debug.Log(random);
				if(random >= 5) //50% chance of encounter
				{	
					thePlayer.disableMovement = true; //disable the player while in combat
					transitionAnim.SetTrigger("end");
					FindObjectOfType<AudioManager>().Play("door");
					yield return new WaitForSeconds(1.5f);
					thePlayer.sceneBeforeBattle = SceneManager.GetActiveScene().name; //set the scene that the player will return after battle;
					thePlayer.GetComponent<SpriteRenderer>().enabled = false;
					SceneManager.LoadScene(levelToLoad); //load the new scene
					
					// yield return new WaitWhile(() => thePlayer.inBattle); //Wait until the
					yield return new WaitForSeconds(4f);  // waits 4 seconds for the chance of another encounter
					Debug.Log("teste");
				}
				else
				{
					yield return new WaitForSeconds(2f);  // waits 2 seconds for the chance of another encounter
				}	
				couritineRunning = false;
		}
	}

}
