using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int[] playerScores = new int[5];
    public string[] playerNames = new string[5];

    public ScoreData (Score score)
    {
        playerScores = score.highScores;
        playerNames = score.highScoreNames;
    }
}