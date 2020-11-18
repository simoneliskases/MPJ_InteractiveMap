﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carOne, carTwo, carThree;
    public Transform carSpawnPoint;
    public Timer timer;

    private void OnEnable()
    {
        StartGame();
    }

    private void StartGame()
    {
        int carIdentifier = PlayerPrefs.GetInt("carIdentifier");
        switch (carIdentifier)
        {
            case 1:
                InstantiateCar(carOne);
                break;
            case 2:
                InstantiateCar(carTwo);
                break;
            case 3:
                InstantiateCar(carThree);
                break;
        }


        string playerName = PlayerPrefs.GetString("playerName");

        print("The car identifier is " + carIdentifier);
        print("Your name is " + playerName);
        timer.timerIsRunning = true;
    }

    private void InstantiateCar(GameObject _car)
    {
        if(_car != null)
        {
            GameObject _instantiatedCar = Instantiate(_car, carSpawnPoint);
            _instantiatedCar.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Car isn't available");
        }
    }
}