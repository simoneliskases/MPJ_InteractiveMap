using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeBoost;
    public TextMeshProUGUI textField;
    public Score score;
    [HideInInspector]
    public bool timerIsRunning = false;
    private float timeRemaining;

    private void OnEnable()
    {
        timeRemaining = RestrictedSettings.minigameTime;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                score.TimeIsOut();
                SceneManager.LoadScene(0);
            }
        }        
    }

    private void DisplayTime(float _timeToDisplay)
    {
        _timeToDisplay += 1;

        float _minutes = Mathf.FloorToInt(_timeToDisplay / 60);
        float _seconds = Mathf.FloorToInt(_timeToDisplay % 60);

        textField.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }

    public void TimeBoost()
    {
        timeRemaining += timeBoost;
    }
}
