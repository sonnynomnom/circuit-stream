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

    public Vector2 minimumXandY;
    public Vector2 maximumXandY;

    public GameObject muffinTextReward;

    public int textRewardDuration = 10;

    public float textAnimationSpeed = 10;

    public RectTransform myRectTransform;
    public RectTransform referenceToHeader;

    private List<MuffinRewardAnimationInfo> allRewardsInfo; 

    public void OnMuffinClick()
    {
        AddMuffins(muffinsPerClick);
        UpdateTextUI();
        CreateTextReward();
    }

    // Start is called before the first frame update
    void Start()
    {
        print(message: "Start called");
        myRectTransform = GetComponent<RectTransform>();

        allRewardsInfo = new List<MuffinRewardAnimationInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation the spinlight every frame
        // spinLights.Rotate(0, 0, spinSpeed * Time.deltaTime);
        AnimateSpinLights();
        AnimateAllRewardInfos();
    }

    public void AnimateSpinLights()
    {
        for (int index = 0; index < spinLights.Length; index = index + 1)
        {
            float currentSpeed = spinSpeed;

            if (index % 2 == 0)
            {
                currentSpeed = currentSpeed * 2;
            }

            spinLights[index].Rotate(xAngle: 0, yAngle: 0, zAngle: currentSpeed * Time.deltaTime);
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

    public void CreateTextReward()
    {
        Vector2 pos = GetRandomPosition();
        GameObject newTextReward = Instantiate(muffinTextReward, myRectTransform);

        newTextReward.transform.localPosition = pos;

        MuffinRewardAnimationInfo animInfo = new MuffinRewardAnimationInfo();

        animInfo.transform = newTextReward.GetComponent<RectTransform>();
        animInfo.textField = newTextReward.GetComponent<TMP_Text>();

        allRewardsInfo.Add(animInfo);

    }

    public void AnimateAllRewardInfos()
    {
        List<MuffinRewardAnimationInfo> expiredAnimations = new List<MuffinRewardAnimationInfo>();

        foreach (MuffinRewardAnimationInfo currentInfo in allRewardsInfo)
        {

            bool shouldDestroy = !AnimateRewardInfo(currentInfo);

            if (shouldDestroy)
            {
                expiredAnimations.Add(currentInfo);
            }
        }

        foreach (MuffinRewardAnimationInfo currentInfo in expiredAnimations)
        {
            allRewardsInfo.Remove(currentInfo);
            currentInfo.Destroy();
        }

    }

    public bool AnimateRewardInfo(MuffinRewardAnimationInfo info)
    {
        info.elapsedTime += Time.deltaTime;

        info.transform.anchoredPosition += Vector2.up * textAnimationSpeed * Time.deltaTime;

        Color currentColor = info.textField.color;
        currentColor.a = Mathf.Lerp(1, 0, info.elapsedTime / textRewardDuration);
        info.textField.color = currentColor;

        if (info.elapsedTime <= textRewardDuration)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public Vector2 GetRandomPosition()
    {

        float x = Random.Range(minimumXandY.x, maximumXandY.x);
        float y = Random.Range(minimumXandY.y, maximumXandY.y);

        return new Vector2(x,y);

    }

}
