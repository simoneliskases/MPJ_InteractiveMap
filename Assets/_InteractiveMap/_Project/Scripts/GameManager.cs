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
        timer.timerIsRunning = true;
    }
}