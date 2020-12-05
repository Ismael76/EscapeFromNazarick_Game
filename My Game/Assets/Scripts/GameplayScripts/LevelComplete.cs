using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject panelEnd;
    public GameObject lvlEndSound;

    public static bool isLevelComplete = false;

    void OnTriggerEnter(Collider other)
    {
        panelEnd.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        lvlEndSound.GetComponent<AudioSource>().Play();
        TutEnd.isTutFinished = true;
        isLevelComplete = true;

    }

}
