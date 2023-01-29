using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    public Achievement newVideoAmountAchievement;
    public Achievement subscriberAmountAchievement;

    public Transform achievementPanel;
    public Text achievementNameText;
    public Text achievementDescriptionText;

    private int _videoAmount;
    private int _subscriberAmount;

    private void OnEnable()
    {
        FindObjectOfType<UIManager>().UploadNewVideoAction += UploadNewVideo;
        FindObjectOfType<UIManager>().GetNewSubscriberAction += GetSubscriber;
    }

    private void OnDisable()
    {
        FindObjectOfType<UIManager>().UploadNewVideoAction -= UploadNewVideo;
        FindObjectOfType<UIManager>().GetNewSubscriberAction -= GetSubscriber;
    }

    private void UploadNewVideo()
    {
        if (newVideoAmountAchievement.unlocked)
            return;

        _videoAmount += 10;

        if (_videoAmount >= 100)
            PopNewAchievement(newVideoAmountAchievement);
    }

    private void GetSubscriber()
    {
        if (subscriberAmountAchievement.unlocked)
            return;

        _subscriberAmount += 10;
        if (_subscriberAmount >= 100)
            PopNewAchievement(subscriberAmountAchievement);
    }

    private void PopNewAchievement(Achievement achieve)
    {
        achievementNameText.text = achieve.achievementName;
        achievementDescriptionText.text = achieve.achievementDescription;

        achieve.unlocked = true;

        StartCoroutine(PopThePanel());
    }

    private IEnumerator PopThePanel()
    {
        float percent = 0;
        const float amount = 165f;

        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            achievementPanel.position += Vector3.down * (amount * Time.deltaTime) / 1f;

            yield return null;
        }

        yield return new WaitForSeconds(1);

        percent = 0;
        
        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            achievementPanel.position += Vector3.up * (amount * Time.deltaTime) / 1f;

            yield return null;
        }
    }
}

[Serializable]
public class Achievement
{
    public string achievementName;
    public string achievementDescription;
    public bool unlocked;
}