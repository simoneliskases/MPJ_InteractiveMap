﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestrictedSettings : MonoBehaviour
{
    public GameObject settings, password, popUp;
    public TMP_InputField passwordInput;
    private string _password = "123";

    private void OnEnable()
    {
        SetActive(false, true, false);
        passwordInput.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (passwordInput.text == _password)
            {
                SetActive(true, false, false);
            }
            else
            {
                Debug.LogWarning("The password is " + _password + ", but you wrote " + passwordInput.text);
            }
        }
    }

    public void DeleteData()
    {
        SetActive(false, false, true);
    }

    public void Submit()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Cancel()
    {
        SetActive(true, false, false);
    }

    private void OnDisable()
    {
        SetActive(false, false, false);
    }

    private void SetActive(bool _settings, bool _password, bool _popUp)
    {
        settings.SetActive(_settings);
        password.SetActive(_password);
        popUp.SetActive(_popUp);
    }
}
