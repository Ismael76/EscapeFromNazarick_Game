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

        currentTime -= 1 * Time.deltaTime;
        
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (currentTime < 10) {

            countdownText.color = Color.red;
        }

        if (currentTime <= 0) {

            currentTime = startTime;
            FindObjectOfType<PlayerHealth>().GameOver2();

        } 
        
    }
}
