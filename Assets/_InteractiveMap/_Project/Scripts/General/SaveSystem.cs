using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore (int score)
    {
        BinaryFormatter _formatter = new BinaryFormatter();

        string _path = Application.persistentDataPath + "/data.im";
        FileStream _stream = new FileStream(_path, FileMode.Create);
    }
}