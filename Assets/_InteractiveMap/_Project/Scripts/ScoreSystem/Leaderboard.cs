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
            textFields[i-1].text = PlayerPrefs.GetString("highScoreName" + i) + ": " + PlayerPrefs.GetInt("highScorePos" + i);
        }
    }
}
