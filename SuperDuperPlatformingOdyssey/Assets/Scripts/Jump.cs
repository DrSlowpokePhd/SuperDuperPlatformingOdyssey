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
    [SerializeField]
    Text jumpComboDisplay;
    Rigidbody2D rb;
    private int jumpNum = 0;
    private int totalJumpCycle = 0;
    Stopwatch jumpTime = new Stopwatch();
    
    private void OnCollisionEnter2D(Collision2D ground)
    {
        if (jumpNum < 1)
        {
            jumpNum++;
        }
        totalJumpCycle = 0;
        
    }
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	
	void FixedUpdate () {
        //determines when to jump
		if (Input.GetButtonDown("Jump") && jumpNum >= 1 && totalJumpCycle < 10)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpNum--;
            totalJumpCycle++;
            if (jumpTime.IsRunning == false)
            {
                jumpTime.Start();
            } else if (jumpTime.ElapsedMilliseconds <= 500)
            {
                jumpNum++;
                UnityEngine.Debug.Log("Jump Successful");  
                jumpTime.Reset();
            }            
        }

        jumpComboDisplay.text = "Jump Chain: " + totalJumpCycle;

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
	}

   
}
