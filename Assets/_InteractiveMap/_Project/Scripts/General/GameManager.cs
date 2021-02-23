using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carOne, carTwo, carThree;
    public Transform carSpawnPoint;
    public Timer timer;

    private GameObject _instantiatedCar;

    private void Awake()
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

        timer.timerIsRunning = true;
    }

    private void InstantiateCar(GameObject _car)
    {
        if(_car != null)
        {
            _instantiatedCar = Instantiate(_car, carSpawnPoint);
            _instantiatedCar.SetActive(true);
            SetSingleton();
        }
        else
        {
            Debug.LogWarning("Car isn't available");
        }
    }

    #region Singleton
    private void SetSingleton()
    {
        currentCar = _instantiatedCar;
    }
    public static GameObject currentCar;
    #endregion
}