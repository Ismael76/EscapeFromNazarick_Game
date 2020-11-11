using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    public Text timerText;

    private float startTime;

    private bool finished = false;

    void Start() {

        timerText.text = "Time: 00:00.00";
        startTime = Time.time; //Gives Time Since Beginning Of Game Level

    }

    void Update() {

        if (finished) {
            return;
        } else {
            float t = Time.time - startTime; //Amount Of Time Since Timer Has Started


            //Gives Mins + Secs Of Timer In String Format
            string minutes = ((int) t / 60).ToString();
            string seconds = ((t % 60)).ToString("f2");

            timerText.text = "Time: " + minutes + ":" + seconds;
        }
    }

    public void FinishTimer() {
        finished = true;
        timerText.color = Color.yellow;
    }

    
}
