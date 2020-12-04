using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveBestTime : MonoBehaviour
{

    public Text bestTimeText;

    public float setBestTime;

    public int level;

    void Start()
    {

        if (PlayerPrefs.HasKey("BestTime[" + level + "]"))
        {
            //Getting Best Recorded Time
            float minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("BestTime[" + level + "]") / 60);
            float seconds = Mathf.FloorToInt(PlayerPrefs.GetFloat("BestTime[" + level + "]") % 60);
            bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
        else
        {
            //Setting Best Time On First Playthrough
            PlayerPrefs.SetFloat("BestTime[" + level + "]", setBestTime);
            float minutes = Mathf.FloorToInt(setBestTime / 60);
            float seconds = Mathf.FloorToInt(setBestTime % 60);
            bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void Save()
    {
        //If Current Time Is Smaller Than Currently Saved Time Then It Will Update To Give New Best Time
        if (TimerController.time < PlayerPrefs.GetFloat("BestTime[" + level + "]"))
        {
            float result = Mathf.Round(TimerController.time * 100f) / 100f;
            PlayerPrefs.SetFloat("BestTime[" + level + "]", result);
            TimerController.time = 0f;
        }
        else
        {
            return;
        }

    }
}
