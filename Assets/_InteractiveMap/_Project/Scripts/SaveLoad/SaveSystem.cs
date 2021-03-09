using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScores(Score score)
    {
        BinaryFormatter _formatter = new BinaryFormatter();

        string _path = Application.persistentDataPath + "/scores.im";
        FileStream _stream = new FileStream(_path, FileMode.Create);

        ScoreData data = new ScoreData(score);

        _formatter.Serialize(_stream, data);
        _stream.Close();
    }

    public static void SaveSettings(RestrictedSettings settings)
    {
        BinaryFormatter _formatter = new BinaryFormatter();

        string _path = Application.persistentDataPath + "/settings.im";
        FileStream _stream = new FileStream(_path, FileMode.Create);

        SettingsData data = new SettingsData(settings);

        _formatter.Serialize(_stream, data);
        _stream.Close();
    }

    public static ScoreData LoadScores()
    {
        string _path = Application.persistentDataPath + "/scores.im";
        if (File.Exists(_path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + _path);
            return null;
        }
    }

    public static SettingsData LoadSettings()
    {
        string _path = Application.persistentDataPath + "/settings.im";
        if (File.Exists(_path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);

            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + _path);
            return null;
        }
    }

    public static void DeleteScores()
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string _path = Application.persistentDataPath + "/scores.im";

        if (File.Exists(_path))
        {
            File.Delete(_path);
        }
        else
        {
            Debug.LogWarning("Save file not found in " + _path);
        }
    }

    public static void DeleteSettings()
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string _path = Application.persistentDataPath + "/settings.im";

        if (File.Exists(_path))
        {
            File.Delete(_path);
        }
        else
        {
            Debug.LogWarning("Save file not found in " + _path);
        }
    }
}   