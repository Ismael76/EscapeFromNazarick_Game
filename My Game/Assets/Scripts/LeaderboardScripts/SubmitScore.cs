using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

public class SubmitScore : MonoBehaviour
{
    public TMP_InputField textBox;
    public Text finishedTimerText2;

    public void Submit()
    {
        PlayerPrefs.SetString("name", textBox.text);
        PlayerPrefs.SetString("time", finishedTimerText2.text);
        Debug.Log("Your Name Is: " + PlayerPrefs.GetString("name"));
        Debug.Log("Your Time Is: " + PlayerPrefs.GetString("time"));
    }
}