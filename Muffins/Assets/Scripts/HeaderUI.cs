using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{

    public TMP_Text muffinsText;

    public GameManager gameManager;

    public void UpdateTextUI()
    {
        muffinsText.text = gameManager.numberOfEarnedMuffins.ToString();
    }

    public void Update()
    {
        UpdateTextUI();
    }
}
