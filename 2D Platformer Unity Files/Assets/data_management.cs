using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class data_management : MonoBehaviour
{
    public static data_management datamanagement;

    public float highScore;
    void Awake()
    {
        if(datamanagement == null)
        {
            DontDestroyOnLoad(gameObject);
            datamanagement = this;
        }else if(datamanagement != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter binForm = new BinaryFormatter(); //creates binaryt file
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //creates file
        gameData data = new gameData(); //creates container for data
        data.highscore = highScore;
        binForm.Serialize(file, data); //serializes 
        file.Close();
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)binForm.Deserialize(file);
            file.Close();
            highScore = data.highscore;
        }
    }
}

[Serializable]
class gameData
{
    public float highscore;
}