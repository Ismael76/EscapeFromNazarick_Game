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

        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);

        PauseMenu.isGamePaused = false;

        TutEnd.isTutFinished = false;
        

    }

    public void LoadTutorial() {

        Time.timeScale = 1f;
        CameraController.rotationSpeed = 5f;
        SceneManager.LoadScene("Tut Level"); 

    }

    public void QuitGame()
    { //To Quit Out Of The Game

        Application.Quit();

    }

}
