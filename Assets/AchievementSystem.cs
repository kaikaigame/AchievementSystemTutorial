using System.Collections;
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

    private void Start()
    {
        FindObjectOfType<UIManager>().UploadNewVideoAction += UploadNewVideo;
        FindObjectOfType<UIManager>().GetNewSubscriberAction += GetSubscriber;
    }

    void UploadNewVideo()
    {
        if (newVideoAmountAchievement.unlocked)
            return;

        _videoAmount += 10;
        if (_videoAmount >= 100)
            PopNewAchievement(newVideoAmountAchievement);
    }

    void GetSubscriber()
    {
        if (subscriberAmountAchievement.unlocked)
            return;

        _subscriberAmount += 10;
        if (_subscriberAmount >= 100)
            PopNewAchievement(subscriberAmountAchievement);
    }

    void PopNewAchievement(Achievement achieve)
    {
        achievementNameText.text = achieve.achievementName;
        achievementDescriptionText.text = achieve.achievementDescription;

        achieve.unlocked = true;

        StartCoroutine(PopThePanel());
    }

    IEnumerator PopThePanel()
    {
        float percent = 0;
        float amount = 165f;

        while(percent < 1)
        {
            percent += Time.deltaTime / 1f;
            achievementPanel.position += Vector3.down * amount * Time.deltaTime / 1f;

            yield return null;
        }

        yield return new WaitForSeconds(1);

        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            achievementPanel.position += Vector3.up * amount * Time.deltaTime / 1f;

            yield return null;
        }
    }
}

[System.Serializable]
public class Achievement
{
    public string achievementName;
    public string achievementDescription;
    public bool unlocked;
}