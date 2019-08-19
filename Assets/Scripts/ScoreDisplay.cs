using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

    // Display each bowl's scores
    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);
        for(int i = 0; i < scoresString.Length; i++)
        {
            rollTexts[i].text = scoresString[i].ToString();
        }
    }

    // Display each frame's scores
    public void FillFrames(List<int> frames)
    {
        for(int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    // return a string of each bowl's scores
    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for(int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;

            if(rolls[i] == 0)                                                        // Score 0
            {
                output += "-";
            }
            else if((box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10)    // SPARE
            {
                output += "/";
            }
            else if(box >= 19 && rolls[i] == 10)                                     // STRIKE in frame 10
            {
                output += "X";
            }
            else if(rolls[i] == 10)                                                  // STRIKE
            {
                output += "X ";
            }
            else                                                                     // Score 1~9
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}
