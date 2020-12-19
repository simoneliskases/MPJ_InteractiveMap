using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestrictedSettings : MonoBehaviour
{
    public GameObject settings, password, popUp;
    public TMP_InputField passwordInput;
    public TMP_Dropdown dropdown;
    private string _password = "123";

    private void OnEnable()
    {
        SetActive(false, true, false);
        passwordInput.text = "";

        switch (PlayerPrefs.GetFloat("minigameTime"))
        {
            case 60:
                dropdown.value = 0;
                break;
            case 90:
                dropdown.value = 1;
                break;
            case 120:
                dropdown.value = 2;
                break;
        }
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

    public void MinigameTimeInput()
    {
        switch (dropdown.value)
        {
            case 0:
                ChangeMinigameTime(60);
                break;
            case 1:
                ChangeMinigameTime(90);
                break;
            case 2:
                ChangeMinigameTime(120);
                break;
        }
    }

    private void ChangeMinigameTime(float time)
    {
        PlayerPrefs.SetFloat("minigameTime", time);
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
