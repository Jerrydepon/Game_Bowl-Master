using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    // Use event trigger to move ball in x position
    public void MoveStart(float amount)
    {   
        if(ball.inPlay == false)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    // The position and time of mouse clicked
    public void DragStart()
    {   
        if(ball.inPlay == false)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    // The position and time of mouse released & Calculate the ball's speed
    public void DragEnd()
    {
        if (ball.inPlay == false)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Launch(launchVelocity);
        }
    }
}
