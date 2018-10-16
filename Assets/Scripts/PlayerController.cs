using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {



    int coinCount = 0;
    int playerLivesCount = 3;
    [SerializeField]
    Text playerScore;
    [SerializeField]
    Text playerLives;
    [SerializeField]
    Text deathText;
    
    [SerializeField]
    private Button returnToMainMenu;
    private Rigidbody2D player;
    [SerializeField]
    private Collider2D Plat1, Plat2;
    
    [SerializeField]
    private float movementSpeed;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Rigidbody2D>();
        returnToMainMenu.gameObject.SetActive(false);
	}
	
	// FixedUpdate is used for physics and things that need to be updated at a fixed interval
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");//variable for horizontal speed
        player.velocity = new Vector2(horizontal * movementSpeed, player.velocity.y);
        Debug.Log("Horizontal: " + horizontal);
	}

    private void Update()
    {
        //display lives and coin count as text
        playerScore.text = "Coins: " + coinCount;
        playerLives.text = "Lives: " + playerLivesCount;       

        if (playerLivesCount > 0)
        {
            returnToMainMenu.gameObject.SetActive(false);
        } 
        else if(playerLivesCount == 0)
        {
            returnToMainMenu.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("pickup"))
        {
            collision.gameObject.SetActive(false);
            coinCount++;
        }

        if (collision.gameObject.CompareTag("plat1"))
            Plat2.gameObject.SetActive(false);

        if (collision.gameObject.CompareTag("plat2"))
            Plat1.gameObject.SetActive(false);

        //respawn if player dies
        if (collision.gameObject.CompareTag("death") && playerLivesCount > 1)
        {
            transform.position = new Vector2(0, 14);
            playerLivesCount--;
            
        } else if (collision.gameObject.CompareTag("death") && playerLivesCount <= 1)
        {
            //game over condition
            playerLives.text = "Lives: 0";
            player.gameObject.SetActive(false);
            deathText.text = "Game Over";
            deathText.fontSize = 80;
            returnToMainMenu.gameObject.SetActive(true);
        }
    }
}
