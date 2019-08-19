using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;
    private GameManager gameManager;
    private PinCounter pinCounter;
    private float launchTime;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

    // Score 0 if ball staying too long on the lane without hitting
    void Update()
    {
        if (inPlay == true && pinCounter.ballOutOfPlay == false && Time.time - launchTime > 25)
        {
            gameManager.Bowl(0);
        }
    }

    // Launch the ball
    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource.Play();

        launchTime = Time.time;
    }
	
    // Reset the ball
    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}
