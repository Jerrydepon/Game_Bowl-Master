using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingTreshold = 180f;
    public float distanceToRaise = 40f;

    private Rigidbody rigidBody;
    
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Determine if the pins standing
    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingTreshold && tiltInZ < standingTreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Raise the pins if standing
    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    // Lower the pins
    public void Lower()
    {
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigidBody.useGravity = true;
    }
}
