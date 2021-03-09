using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public int[] highScores = new int[5];
    [HideInInspector]
    public string[] highScoreNames = new string[5];

    public TextMeshProUGUI textField;
    [HideInInspector]
    public int coinCount; //Is updated by CarController script

    private int playerScore;
    private int tempScore;

    private string playerName;
    private string tempName;

    private void Awake()
    {
        ScoreData data = SaveSystem.LoadScores();
        if (data != null)
        {
            highScores = data.playerScores;
            highScoreNames = data.playerNames;
        }
    }

    private void Update()
    {
        textField.text = coinCount.ToString();
    }

    public void TimeIsOut()
    {
        playerScore = coinCount;
        playerName = PlayerPrefs.GetString("playerName");

        for (int i=1; i<=5; i++)
        {
            if(highScores[i - 1] < playerScore)
            {
                tempScore = highScores[i - 1];
                highScores[i - 1] = playerScore;

                tempName = highScoreNames[i - 1];
                highScoreNames[i - 1] = playerName;

                if (i < 5)
                {
                    int j = i + 1;

                    playerScore = highScores[j - 1];
                    highScores[j - 1] = tempScore;

                    playerName = highScoreNames[j - 1];
                    highScoreNames[j - 1] = tempName;
                }
            }
        }

        SaveSystem.SaveScores(this);
    }
}
