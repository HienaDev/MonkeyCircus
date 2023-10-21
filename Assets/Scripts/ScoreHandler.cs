using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler
{
    public int currentScore {get; private set;}
    
    private int baseTimeBonus;

    public void EndLevelScore(float expectedCompletionTime, float completionTime)
    {
        int timeComparison = (int)(expectedCompletionTime - completionTime);
        if(timeComparison < 0)
            timeComparison = 0;

        int timeBonus = baseTimeBonus * timeComparison;
    }

    public void AddPoints(int value)
    {
        currentScore += value;
    }
}
