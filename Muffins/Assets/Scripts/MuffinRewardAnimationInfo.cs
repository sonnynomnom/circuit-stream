using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuffinRewardAnimationInfo : MonoBehaviour
{
    public RectTransform transform;
    public TMP_Text textField;

    public float ellapsedTime = 0;

    public void Destroy()
    {
        Destroy(transform.gameObject);
    }
}