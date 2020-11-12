using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Muffin : MonoBehaviour
{

    public int numberOfEarnedMuffins = 0;
    public int muffinsPerClick = 1;

    public TMP_Text muffinsText;
    public RectTransform[] spinLights;
    public float spinSpeed = 20;

    public void OnMuffinClick()
    {
        AddMuffins(muffinsPerClick);
        UpdateTextUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Start called");
    }
    
    // Update is called once per frame
    void Update()
    {
        // Rotation the spinlight every frame
        // spinLights.Rotate(0, 0, spinSpeed * Time.deltaTime);
        AnimateSpinLights();    
    }

    public void AnimateSpinLights()
    {
        for(int index = 0; index < spinLights.Length; index = index + 1)
        {
            spinLights[index].Rotate(0, 0, spinSpeed * Time.deltaTime);
        }
    }

    public void UpdateTextUI()
    {
        muffinsText.text = numberOfEarnedMuffins.ToString();
    }

    public void AddMuffins(int muffinsToAdd)
    {
        numberOfEarnedMuffins = numberOfEarnedMuffins + muffinsToAdd;
    }

}
