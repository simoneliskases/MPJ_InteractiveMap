using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public string highScorePos = "highScorePos";
    public string highScoreName = "highScoreName";
    [HideInInspector]
    public int coinCount;

    private int playerScore;
    private int tempScore;

    private string playerName;
    private string tempName;

    private bool levelIsCompleted;

    private void Start()    
    {
        levelIsCompleted = false;
    }

    private void Update()
    {
        textField.text = coinCount.ToString();
    }

    public void TimeIsOut()
    {
        levelIsCompleted = true;
        playerScore = coinCount;
        playerName = PlayerPrefs.GetString("playerName");

        for (int i=1; i<=5; i++)
        {
            if(PlayerPrefs.GetInt(highScorePos + i) < playerScore)
            {
                tempScore = PlayerPrefs.GetInt(highScorePos + i);
                PlayerPrefs.SetInt(highScorePos + i, playerScore);

                tempName = PlayerPrefs.GetString(highScoreName + i);
                PlayerPrefs.SetString(highScoreName + i, playerName);

                if (i < 5)
                {
                    int j = i + 1;

                    playerScore = PlayerPrefs.GetInt(highScorePos + j);
                    PlayerPrefs.SetInt(highScorePos + j, tempScore);

                    playerName = PlayerPrefs.GetString(highScoreName + j);
                    PlayerPrefs.SetString(highScoreName + j, tempName);
                }
            }
        }
    }

    private void OnGUI()
    {
        if (levelIsCompleted)
        {
            for (int i=1; i<=5; i++)
            {
                GUI.Box(new Rect(100, 300+75*i, 250, 50), "Platz " +i+ ": " + PlayerPrefs.GetString(highScoreName + i) + " mit " + PlayerPrefs.GetInt(highScorePos + i) + " coins");
            }
        }
    }
}
