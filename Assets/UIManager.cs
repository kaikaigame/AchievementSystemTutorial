using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text newVideoText;
    public Text subscriberText;

    public int newVideoAmount;
    public int subscriberAmount;

    public event Action UploadNewVideoAction;
    public event Action GetNewSubscriberAction;

    public void UploadNewVideoUI()
    {
        newVideoAmount += 10;
        newVideoText.text = "VIDEO: " + newVideoAmount;

        if (UploadNewVideoAction != null)
            UploadNewVideoAction();
    }

    public void GetSubscriberUI()
    {
        subscriberAmount += 10;
        subscriberText.text = "SUBSCRIBER: " + subscriberAmount;

        if (GetNewSubscriberAction != null)
            GetNewSubscriberAction();
    }
}

