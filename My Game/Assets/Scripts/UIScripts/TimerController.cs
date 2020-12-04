using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    public Text countdownText;

    public float startTime;

    private float currentTime = 0;

    public static float time = 0f;

    void Start() {

        currentTime = startTime;

    }

    //Counts Down The Time & If It Reaches 0 It Will Display GameOver Screen That Says Time Limit Reached
    void Update() {
        
        time += 1 * Time.deltaTime;

        string seconds = (time % 60).ToString("00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime < 10) {

            countdownText.color = Color.red;
        }

        if (currentTime <= 0) {

            currentTime = startTime;
            FindObjectOfType<PlayerHealth>().GameOver2();

        } 
        
    }
}
