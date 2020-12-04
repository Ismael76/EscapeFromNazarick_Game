using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoad : MonoBehaviour
{
    public Animator transitions;

    private int checkIfFirstTime;

    public void LoadGame()
    { //To Load The Game & Levels

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel (int levelIndex) {

        PauseMenu.isGamePaused = false;

        TutEnd.isTutFinished = false;

        PlayerHealth.isGameOver = false;

        OffMapDeath.playerIsOffMap = false;

        PowerUpCoolDown3.isCoolDown = false;
        PowerUpCoolDown2.isCoolDown = false;
        PowerUpCoolDown.isCoolDown = false;
        PowerUp3.isUsingPowerUp3 = false;
        PowerUp2.isUsingPowerUp2 = false;
        PowerUp.isUsingPowerUp1 = false;

        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);

        

    }

    public void LoadTutorial() {

        if (checkIfFirstTime == 0) {

            SaveBestTime.firstPlayInt = 1;
        }

        Time.timeScale = 1f;
        CameraMovement.rotationSpeed = 5f;
        PlayerHealth.isGameOver = false;
        TutEnd.isTutFinished = false;
        PauseMenu.isGamePaused = false;
        OffMapDeath.playerIsOffMap = false;
        PowerUpCoolDown3.isCoolDown = false;
        PowerUpCoolDown2.isCoolDown = false;
        PowerUpCoolDown.isCoolDown = false;
        PowerUp3.isUsingPowerUp3 = false;
        PowerUp2.isUsingPowerUp2 = false;
        PowerUp.isUsingPowerUp1 = false;
        SceneManager.LoadScene("Tut Level");
        checkIfFirstTime ++;

    }

    public void LoadLevel1() {

         if (checkIfFirstTime == 0) {

            SaveBestTime.firstPlayInt = 1;
        }

        Time.timeScale = 1f;
        CameraMovement.rotationSpeed = 5f;
        PlayerHealth.isGameOver = false;
        TutEnd.isTutFinished = false;
        PauseMenu.isGamePaused = false;
        OffMapDeath.playerIsOffMap = false;
        PowerUpCoolDown3.isCoolDown = false;
        PowerUpCoolDown2.isCoolDown = false;
        PowerUpCoolDown.isCoolDown = false;
        PowerUp3.isUsingPowerUp3 = false;
        PowerUp2.isUsingPowerUp2 = false;
        PowerUp.isUsingPowerUp1 = false;
        SaveBestTime.firstPlayInt = 1;
        SceneManager.LoadScene("Level1");

    }

    public void LoadLevel2() {

        Time.timeScale = 1f;
        CameraMovement.rotationSpeed = 5f;
        PlayerHealth.isGameOver = false;
        TutEnd.isTutFinished = false;
        PauseMenu.isGamePaused = false;
        OffMapDeath.playerIsOffMap = false;
        PowerUpCoolDown3.isCoolDown = false;
        PowerUpCoolDown2.isCoolDown = false;
        PowerUpCoolDown.isCoolDown = false;
        PowerUp3.isUsingPowerUp3 = false;
        PowerUp2.isUsingPowerUp2 = false;
        PowerUp.isUsingPowerUp1 = false;
        SaveBestTime.firstPlayInt = 1;
        SceneManager.LoadScene("Level2");

    }

    public void LoadLevel3() {

         if (checkIfFirstTime == 0) {

            SaveBestTime.firstPlayInt = 1;
        }

        Time.timeScale = 1f;
        CameraMovement.rotationSpeed = 5f;
        PlayerHealth.isGameOver = false;
        TutEnd.isTutFinished = false;
        PauseMenu.isGamePaused = false;
        OffMapDeath.playerIsOffMap = false;
        PowerUpCoolDown3.isCoolDown = false;
        PowerUpCoolDown2.isCoolDown = false;
        PowerUpCoolDown.isCoolDown = false;
        PowerUp3.isUsingPowerUp3 = false;
        PowerUp2.isUsingPowerUp2 = false;
        PowerUp.isUsingPowerUp1 = false;
        SceneManager.LoadScene("Level3");
        checkIfFirstTime ++;

    }

    public void QuitGame()
    { //To Quit Out Of The Game

        Application.Quit();

    }

    public void SettingsMenu() {

        SceneManager.LoadScene("SettingMenu");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");

    }

}
