using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour
{

    public Text standingDisplay;
    public bool ballOutOfPlay = false;

    private GameManager gameManager;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int lastSettledCount = 10;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            standingDisplay.color = Color.red;
            UpdateStandingCountAndSettle();
        }
    }

    // Reset lastSettledCount
    public void Reset()
    {
        lastSettledCount = 10;
    }

    // Detect if ball out of play to trigger RESET
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }

    // Count the standing pins
    int CountStanding()
    {
        int standingNumber = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standingNumber++;
            }
        }

        return standingNumber;
    }

    //  Check if the bowl ended
    void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 4f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinHaveSettled();
        }
    }

    // Call GameManager and continue next move
    void PinHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall); 

        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }
}
