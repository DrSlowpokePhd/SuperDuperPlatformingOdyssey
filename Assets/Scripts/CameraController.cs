using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    protected Transform trackingTarget;

    [SerializeField]
    float xOffset, yOffset;

    [SerializeField]
    protected float followSpeed;

    [SerializeField]
    protected bool isYLocked = false;

    [SerializeField]
    protected bool isXLocked = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {

        //variables keep track of x and y position of the player plus tracking distance
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        float xNew = transform.position.x;

        //checks to see if x axis variable is locked
        if (!isXLocked)
        {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }

        float yNew = transform.position.y;
        if (!isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }
       

        transform.position = new Vector3(xNew, yNew, transform.position.z);
        
	}
}
