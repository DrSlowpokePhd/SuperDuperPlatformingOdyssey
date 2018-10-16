using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerScript : MonoBehaviour {
    //player physics object
    private Rigidbody2D player;
    //use [Range(a, b)] to add a slider to the variable in the inspector
    [Range(1, 10)]
    public float jumpVelocity;
    public const float fallMultiplier = 2.5f;
    public const float lowJumpMultiplier = 2f;

    //use [SerializeField] to include the variable in the inspector
    [SerializeField]
    private float movementSpeed = 10;

    
    // Use this for initialization
    void Jump()
    {
        //CODE FOR JUMPING
        //determines player velocity
        if (player.velocity.y < 0)
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (player.velocity.y > 0 && !Input.GetButton("Jump"))
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        //determines when to jump
        if (Input.GetButtonDown("Jump"))
            player.velocity = Vector2.up * jumpVelocity;
    }

    void Walk()
    {
        //CODE FOR MOVEMENT
        //variable for horizontal axis
        float horizontal = Input.GetAxis("Horizontal");

        //vector2 is used to move the player character
        player.velocity = new Vector2(horizontal * movementSpeed, player.velocity.y);
    }
    
    void Start ()
    {
        player = gameObject.GetComponent<Rigidbody2D>(); //initializes player object
    }

    //FixedUpdate is called at a fixed interval, and is used for physics and things that need to be updated at a fixed interval
    void FixedUpdate()
    {
        Jump();
        Walk();  
    }
}
