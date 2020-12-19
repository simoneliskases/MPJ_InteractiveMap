using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] textFields;

    private void OnEnable()
    {
        for(int i=1; i<=5; i++)
        {
            string _highScoreName = PlayerPrefs.GetString("highScoreName" + i);
            int _highScorePos = PlayerPrefs.GetInt("highScorePos" + i);

            if(_highScoreName != null && _highScorePos != 0)
            {
                textFields[i - 1].text = _highScoreName + ": " + _highScorePos;
            }
            else
            {
                textFields[i - 1].text = "Not available";
            }           
        }
    }
}
