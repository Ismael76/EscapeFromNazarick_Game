using System.Collections;
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

    }

    public void LoadTutorial() {

        SceneManager.LoadScene("Tut Level");
        PauseMenu.isGamePaused = false;

        PlayerController playerJump = GetComponent<PlayerController>();
        playerJump.jumpForce = 0f;
    }

    public void QuitGame()
    { //To Quit Out Of The Game

        Application.Quit();

    }

}
