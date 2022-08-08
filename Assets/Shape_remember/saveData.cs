using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

public class saveData : MonoBehaviour
{
    private player myPlayer;

    private string DATA_PATH = "/MyGame.dat";

    void Start ()
    {
        SaveData();

        print("DATA Path is " + Application.persistentDataPath + DATA_PATH);


    }

    void SaveData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + DATA_PATH);

            PlayerData p = new PlayerData(6, 28.25);

            bf.Serialize(file, p);

        }
        catch (Exception e)
        {
            if (e != null)
            {

            }

        }
        finally
        { if (file != null)
            {
                file.Close();
            }

        }
    }

}
