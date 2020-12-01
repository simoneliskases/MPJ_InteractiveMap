using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private bool levelIsCompleted;

    public TextMeshProUGUI textField;
    [HideInInspector]
    public int coinCount;

    public string highScorePos = "highScorePos";
    private int score;
    private int tempScore;


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
        score = coinCount;
        
        for (int i=1; i<=5; i++)
        {
            if(PlayerPrefs.GetInt(highScorePos + i) < score)
            {
                tempScore = PlayerPrefs.GetInt(highScorePos + i);
                PlayerPrefs.SetInt(highScorePos + i, score);

                if (i < 5)
                {
                    int j = i + 1;

                    score = PlayerPrefs.GetInt(highScorePos + j);
                    PlayerPrefs.SetInt(highScorePos + j, tempScore);
                }
            }
        }        
    }

    private void OnGUI()
    {
        if (levelIsCompleted)
        {
            for(int i=1; i<=5; i++)
            {
                GUI.Box(new Rect(100, 75 * i, 150, 50), "Platz " +i+ ": " + PlayerPrefs.GetInt(highScorePos + i));
            }
        }
    }
}
