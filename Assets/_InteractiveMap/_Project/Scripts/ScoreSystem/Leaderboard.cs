using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public int highScore;
    public string highScoreKey = "HighScore";


    private void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }
}
