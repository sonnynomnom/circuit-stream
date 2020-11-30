using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int numberOfEarnedMuffins = 0;

    public void Start()
    {
        StartCoroutine(SaveDataPeriodically());
        LoadMyData();
    }

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

    private IEnumerator SaveDataPeriodically()
    {
        while (true == true)
        {
            yield return new WaitForSeconds(2);
            SaveCurrentData();
        }
    }

    public void LoadMyData()
    {
        if (PlayerPrefs.HasKey("progress"))
        {
            string dataAsString = PlayerPrefs.GetString("progress");
            SaveData savedData = (JsonUtility.FromJson(dataAsString, typeof(SaveData)) as SaveData);
        }
    }

    public void SaveCurrentData()
    {
        SaveData currentData = new SaveData();
        currentData.numberOfMuffins = numberOfEarnedMuffins;
        currentData.name = "Jerry";

        SaveMyData(currentData);

    }
}
