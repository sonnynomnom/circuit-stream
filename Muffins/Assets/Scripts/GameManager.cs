using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int numberOfEarnedMuffins = 0;

    public void AddMuffins(int muffinsToAdd)
    {
        numberOfEarnedMuffins = numberOfEarnedMuffins + muffinsToAdd;
    }

    public void SaveMyData(SaveData myData)
    {
        // transforming C# object into text
        string dataAsString = JsonUtility.ToJson(myData);
        
        // sets the text to a "progress" file
        PlayerPrefs.SetString("progress", dataAsString);
        // Debug.Log(dataAsString);
        
        // saves the file in the disk
        PlayerPrefs.Save();

    }

    public void OnApplicationPause(bool pauseStatus)
    {
        SaveData currentData = new SaveData();
        currentData.numberOfMuffins = numberOfEarnedMuffins;
        currentData.name = "Jerry";

        SaveMyData(currentData);
    }

}
