using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public string password;
    public float minigameDuration;

    public SettingsData(RestrictedSettings settings)
    {
        password = RestrictedSettings.pw;
        minigameDuration = RestrictedSettings.minigameTime;
    }
}
