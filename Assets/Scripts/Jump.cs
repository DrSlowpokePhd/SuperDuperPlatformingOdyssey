using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour {

    [Range(1, 10)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rb;
    public int jumpNum = 0;
    
    Stopwatch jumpTime = new Stopwatch();
    
    private void OnCollisionEnter2D(Collision2D ground)
    {
        while (jumpNum <= 5)
        {
            jumpNum++;
        }
        
        
    }
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    

    void FixedUpdate () {
        //determines when to jump
		if (Input.GetButtonDown("Jump") && jumpNum >= 1)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpNum--;
            
        }

        

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
	}

   
}
