using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{

    public Text countdownText;

    public TextMeshProUGUI completionTime;

    public float startTime;

    private float currentTime = 0;

    public static float time = 0f;

    public static float levelCompleteTime;

    void Start() {

        currentTime = startTime;

    }

    //Counts Down The Time & If It Reaches 0 It Will Display GameOver Screen That Says Time Limit Reached
    void Update() {

        currentTime -= 1 * Time.deltaTime;
        
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);


        levelCompleteTime = startTime - currentTime;

        float minutes2 = Mathf.FloorToInt(levelCompleteTime / 60);
        float seconds2 = Mathf.FloorToInt(levelCompleteTime % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        completionTime.text = string.Format("{0:00}:{1:00}", minutes2, seconds2);

        if (currentTime < 10) {

            countdownText.color = Color.red;
        }

        if (currentTime <= 0) {

            currentTime = startTime;
            FindObjectOfType<PlayerHealth>().GameOver2();

        } 
        
    }
}
