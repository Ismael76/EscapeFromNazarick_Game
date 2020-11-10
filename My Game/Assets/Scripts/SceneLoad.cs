﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //To Load Scenes

public class SceneLoad : MonoBehaviour
{
    public Animator transitions;

    public void LoadGame()
    { //To Load The Game & Levels

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel (int levelIndex) {

        PauseMenu.isGamePaused = false;

        TutEnd.isTutFinished = false;

        PlayerHealth.isGameOver = false;

        OffMapDeath.playerIsOffMap = false;

        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
        

    }

    public void LoadTutorial() {

        Time.timeScale = 1f;
        CameraController.rotationSpeed = 5f;
        PlayerHealth.isGameOver = false;
        TutEnd.isTutFinished = false;
        PauseMenu.isGamePaused = false;
        OffMapDeath.playerIsOffMap = false;
        SceneManager.LoadScene("Tut Level"); 

    }

    public void QuitGame()
    { //To Quit Out Of The Game

        Application.Quit();

    }

}
