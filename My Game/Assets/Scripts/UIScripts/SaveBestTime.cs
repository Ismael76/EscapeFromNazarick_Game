using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveBestTime : MonoBehaviour
{

    public Text bestTimeText;
    private static readonly string FirstPlay = "FirstPlay";
    public static int firstPlayInt;

    public float setBestTime;

    public int level;

    void Start()
    {

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        Debug.Log(firstPlayInt);

        if (firstPlayInt == 0)
        {
            //Setting Best Time On First Playthrough
            bestTimeText.text = "N/A";
            PlayerPrefs.SetFloat("BestTime[" + level + "]", setBestTime);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            //Getting Best Recorded Time
            bestTimeText.text = PlayerPrefs.GetFloat("BestTime[" + level + "]").ToString();
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
