using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedMovementsHouses : MonoBehaviour
{
    private Player thePlayer;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnim;
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
        playerRigidbody = thePlayer.GetComponent<Rigidbody2D>();
        playerAnim = thePlayer.GetComponent<Animator>();
        StartCoroutine(ScriptedMove());
    }
    public IEnumerator ScriptedMove()
	{
        Player.movingByScript = true;
        Move();
        yield return new WaitForSecondsRealtime(1f);
        Player.movingByScript = false;

	}
 
    public void Move()
    {
        playerRigidbody.velocity = new Vector2(0f, -1f);
        Player.lastMove = new Vector2 (0f, -1f);
        playerAnim.SetBool("PlayerMoving", Player.playerMoving);
		playerAnim.SetFloat("MoveX", 0f);
		playerAnim.SetFloat("MoveY", -1f);
		playerAnim.SetFloat("LastMoveX",Player.lastMove.x);
		playerAnim.SetFloat("LastMoveY", Player.lastMove.y);
    }

    
}
