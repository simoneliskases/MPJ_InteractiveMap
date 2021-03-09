using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] textFields;
    [HideInInspector]
    public int[] highScores = new int[5];
    [HideInInspector]
    public string[] highScoreNames = new string[5];

    private void OnEnable()
    {
        ScoreData data = SaveSystem.LoadScores();
        if (data == null)
        {
            for(int i = 0; i<5; i++)
            {
                textFields[i].text = "Not available";
            }
            return;
        }

        highScores = data.playerScores;
        highScoreNames = data.playerNames;

        for (int i=0; i<5; i++)
        {
            string _highScoreName = highScoreNames[i];
            int _highScorePos = highScores[i];

            if(_highScoreName != null && _highScorePos != 0)
            {
                textFields[i].text = _highScoreName + ": " + _highScorePos;
            }
            else
            {
                textFields[i].text = "Not available";
            }           
        }
    }
}
