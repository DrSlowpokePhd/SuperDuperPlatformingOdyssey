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
    public Text E;
    [SerializeField]
    AudioSource EE;
    AudioClip EEE;
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
        EE = gameObject.GetComponent<AudioSource>();
        returnToMainMenu.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(horizontal * movementSpeed, player.velocity.y);    
	}

    private void Update()
    {
        //display lives and coin count as text
        playerScore.text = "Coins: " + coinCount;
        playerLives.text = "Lives: " + playerLivesCount;       
        bool memes = true;

        if (playerLivesCount > 0)
        {
            returnToMainMenu.gameObject.SetActive(false);
        } 
        if (coinCount == 16 && playerLivesCount == 3 && memes == true)
        {
            E.text = "E";
            EE.PlayOneShot(EEE, 1);
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
