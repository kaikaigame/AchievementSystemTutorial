using System;
using System.Collections;
using System.Collections.Generic;
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

        UploadNewVideoAction?.Invoke();
    }

    public void GetSubscriberUI()
    {
        subscriberAmount += 10;
        subscriberText.text = "SUBSCRIBER: " + subscriberAmount;

        GetNewSubscriberAction?.Invoke();
    }
}