using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestrictedSettings : MonoBehaviour
{
    public static float minigameTime = 60;
    public static string pw = "123";

    public GameObject settings, password, popUp, back;
    public TMP_InputField passwordInput;
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI popUpMessage;

    private int settingsID;
    private float _tempMinigameTime;

    private void Awake()
    {
        SettingsData data = SaveSystem.LoadSettings();
        if (data != null)
        {
            minigameTime = data.minigameDuration;
            pw = data.password;
        }
        else
        {
            minigameTime = 60;
            pw = "123";
            SaveSystem.SaveSettings(this);
        }

        _tempMinigameTime = minigameTime;
        switch (_tempMinigameTime)
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

    private void OnEnable()
    {
        SetActive(false, true, false, true);
        passwordInput.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (passwordInput.text == pw)
            {
                SetActive(true, false, false, true);
            }
            else
            {
                Debug.LogWarning("The password is " + password + ", but you wrote " + passwordInput.text);
            }
        }
    }

    public void DeleteDataInput() //ID = 1
    {
        SetActive(false, false, true, false);
        ChangePopUpMessage("Do you really want to delete all data ?");
        settingsID = 1;
    }

    private void DeleteData()
    {
        SaveSystem.DeleteScores();
        SaveSystem.DeleteSettings();
    }

    public void MinigameTimeInput() //ID = 2
    {
        SetActive(false, false, true, false);
        ChangePopUpMessage("Do you really want to change the minigame time? All highscores will be lost!");
        settingsID = 2;
    }

    private void ChangeMinigameTime()
    {
        float time = _tempMinigameTime;
        switch (dropdown.value)
        {
            case 0:
                time = 60;
                break;
            case 1:
                time = 90;
                break;
            case 2:
                time = 90;
                break;
        }

        for (int i = 1; i <= 5; i++)
        {
            PlayerPrefs.SetString("highScoreName" + i, null);
            PlayerPrefs.SetInt("highScorePos" + i, 0);
        }

        PlayerPrefs.SetFloat("minigameTime", time);
    }

    private void ChangePopUpMessage(string _message)
    {
        popUpMessage.text = _message;
    }

    public void Submit()
    {
        SetActive(true, false, false, true);
        SaveSystem.SaveSettings(this);

        switch (settingsID)
        {
            case 1:
                DeleteData();
                break;
            case 2:
                ChangeMinigameTime();
                break;
        }
    }

    public void Cancel()
    {
        SetActive(true, false, false, true);
    }

    private void OnDisable()
    {
        SetActive(false, false, false, true);
    }

    private void SetActive(bool _settings, bool _password, bool _popUp, bool _back)
    {
        settings.SetActive(_settings);
        password.SetActive(_password);
        popUp.SetActive(_popUp);
        back.SetActive(_back);
    }
}
