using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static int currentScore {get; private set;}
    
    private TextMeshProUGUI score;

    private int baseTimeBonus;

    private void Start()
    {
        score    = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();   
    }

    private void Update()
    {
        score.text = currentScore.ToString();
    }

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
