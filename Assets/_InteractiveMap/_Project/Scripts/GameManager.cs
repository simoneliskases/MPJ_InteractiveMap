using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject car;
    //public Transform carSpawnPoint;
    public Timer timer;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        //Instantiate(car, carSpawnPoint);
        int carIdentifier = PlayerPrefs.GetInt("carIdentifier");
        string playerName = PlayerPrefs.GetString("playerName");

        print("The car identifier is " + carIdentifier);
        print("Your name is " + playerName);
        timer.timerIsRunning = true;
    }
}