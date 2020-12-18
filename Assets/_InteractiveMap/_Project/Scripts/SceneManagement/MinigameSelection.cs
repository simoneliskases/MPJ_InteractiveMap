﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameSelection : MonoBehaviour
{
    public TMP_InputField inputText;
    public GameObject playButton;

    private string _playerName;
    private int _tempIdentifier;

    private void Update()
    {
        _playerName = inputText.text;

        if(_tempIdentifier != 0 && inputText.text != "")
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    public void SetCar(int identifier)
    {
        _tempIdentifier = identifier;
        if (_tempIdentifier >= 1 && _tempIdentifier <= 3)
        {
            PlayerPrefs.SetInt("carIdentifier", _tempIdentifier);
        }   
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("playerName", _playerName);
    }
}
