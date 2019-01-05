using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{

	public float moveSpeed; //speed that the player will move
	
	private Animator anim;
	public bool playerMoving; 
	public bool disableMovement;//true if the player is moving //true when the player is not inteded to move
    public string sceneBeforeBattle;
	public Vector2 lastMove; //hold the direction of the last move
	private Rigidbody2D myRigidbody;

	private static bool playerExists; //true if the player exists anywhere in the code

    void Start() 
	{	
		FindObjectOfType<AudioManager>().Play("background");
		anim = GetComponent<Animator>(); //get the Animator of the player
		myRigidbody = GetComponent<Rigidbody2D>(); // get the rigidBody of the player

		if(!playerExists) //if player dont exists, dont destroy player on load
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else // else detroy player;
		{
			Destroy(gameObject);
		}
	}


	void Update () 
	{
		Move();
	}

	public void SetToMove(bool value)
	{
		disableMovement = value;
	}

	private void Move() //function that makes the player move
	{	
		playerMoving = false;
		
		if(!disableMovement)
		{
			
			if(Math.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
			{
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * moveSpeed,  myRigidbody.velocity.y); //
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw("Horizontal"), 0f);
			}
			if(Math.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
			{
				myRigidbody.velocity = new Vector2 ( myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw("Vertical"));
			}
			
			if(Math.Abs(Input.GetAxisRaw("Horizontal")) < 0.5f)
			{
				myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
			}

			if(Math.Abs(Input.GetAxisRaw("Vertical")) < 0.5f)
			{
				myRigidbody.velocity = new Vector2( myRigidbody.velocity.x, 0f);
			}
		}
		else
		{
			myRigidbody.velocity = new Vector2(0f, 0f);
		}
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
		
	}


}
	
	
