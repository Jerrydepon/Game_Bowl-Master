using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster{

    // Cumulative scores list
    public static List<int> ScoreCumulative (List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // Scores each frame list
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2)
        {
            if(frames.Count == 10)                              // prevent 11th frame score
            {
                break;
            }

            if (rolls[i - 1] + rolls[i] < 10)                   // normal frame
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if(rolls.Count - i <= 1)                            // Stop counting
            {
                break;
            }

            if(rolls[i - 1] == 10)                              // STRIKE + bonus
            {
                i--; // strike frame has just one bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);   
            }
            else if(rolls[i - 1] + rolls[i] == 10)              // SPARE + bonus
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
    }
}
