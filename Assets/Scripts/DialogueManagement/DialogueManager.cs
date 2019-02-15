using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	[SerializeField] private GameObject dBox; //dialog box
	[SerializeField] private Text dText; //text inside the box 
	public bool dialogueActive; //true if dialog is active
	public bool endDialogueActive;//show that the actual dialogue has endend
	private Queue<string> sentences; //phrases that will be sent in the character box
	private Player thePlayer; //instance of the player
	private bool firstSentence; //the first sentence of the dialogue is the one that will be shown?(Brute force solution :c)
	private string actualSentence;//the sentence that will be shown
	private bool sentenceRunning;//check if the sentence is running (brute force solution)
	private Coroutine showSentenceCoroutine;//store the coroutine ShowSentence. Necessary to stop the coroutine when needed
	void Start () 
	{
		thePlayer = FindObjectOfType<Player>(); //Find player in the scene
		sentences = new Queue<string>(); //initializes the string queue
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if(firstSentence) //activates without the necessity of the input
		{
			showSentenceCoroutine = StartCoroutine(ShowSentence(actualSentence = sentences.Dequeue())); 
			firstSentence = false;  
		}
		else if(sentenceRunning && Input.GetKeyDown(KeyCode.Z)) //if the sentence is still running, and is pressed to pass, shown the full sentence
		{	
			StopCoroutine(showSentenceCoroutine);  //stop that show the sentence
			dText.text = actualSentence; //set the text to the actual sentence
			sentenceRunning = false;
		}
		else if(dialogueActive && Input.GetKeyDown(KeyCode.Z) )
		{	
			if(sentences.Count == 0) //if the npc dialogue has endend;
			{
				dBox.SetActive(false);
				thePlayer.disableMovement = false;
				dialogueActive = false;
				endDialogueActive = true;
			}
			else
			{
				showSentenceCoroutine = StartCoroutine(ShowSentence(actualSentence = sentences.Dequeue())); //goes to the next sentence
			}
		}
		
	}

	IEnumerator ShowSentence(string sentence) //show the sentence in the dialogue box letter by letter
	{	
		sentenceRunning = true;
		dText.text = "";
		foreach (char letter in sentence)
		{
			dText.text += letter;
			yield return null; // a latter by frame	
		}
		sentenceRunning = false; 	
	}

	public void StartDialogue(Dialogue dialogue)
	{
		if(!dialogueActive) //if the dialogue is not active, activate it;
		{	
			foreach (string sentence in dialogue.sentences) //set the sentences queue
				sentences.Enqueue(sentence);
			thePlayer.disableMovement = true; //the player cant move during dialogue;			
			dBox.SetActive(true); //set active the dialogue box
			dialogueActive = true; //start the dialogues
			firstSentence = true;
		}
	}
}
