using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public Text finishedTimerText;
    public Text finishedTimerText2;
    public GameObject panelEnd;
    public GameObject lvlEndSound;

    void OnTriggerEnter(Collider other)
    {
        panelEnd.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        lvlEndSound.GetComponent<AudioSource>().Play();
        TutEnd.isTutFinished = true;

        GameObject.Find("Timer").SendMessage("FinishTimer");
        finishedTimerText.text = PlayerPrefs.GetString("timerValue");
        finishedTimerText2.text = PlayerPrefs.GetString("timerValue");

    }

}
