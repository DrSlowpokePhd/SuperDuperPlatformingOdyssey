using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorPlat : MonoBehaviour {

    Rigidbody2D player;
    [SerializeField]
    public JointMotor2D motorPlat;
    
	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Rigidbody2D>();
        motorPlat = gameObject.GetComponent<JointMotor2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Jump"))
        {
            motorPlat.motorSpeed *= -1;
        }
	}
}
