using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Animator transitions;

    public static bool isLevel3 = false;
    public static bool isLevel2 = false;
    public static bool isLevel1 = false;

    public void LoadGame()
    { //To Load The Game & Levels

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
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

        PlayerHealth.invincibilityLength = 2f;
        PlayerHealth.isInvincible = false;
        TimerController.time = 0f;
        Time.timeScale = 1f;
        CameraMovement.rotationSpeed = 5f;

        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);



    }

    public void LoadTutorial()
    {
        PlayerHealth.invincibilityLength = 2f;
        PlayerHealth.isInvincible = false;
        TimerController.time = 0f;
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

    }

    public void LoadLevel1()
    {
        PlayerHealth.invincibilityLength = 2f;
        PlayerHealth.isInvincible = false;
        TimerController.time = 0f;
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
        SceneManager.LoadScene("Level1");

    }

    public void LoadLevel2()
    {
        PlayerHealth.invincibilityLength = 2f;
        PlayerHealth.isInvincible = false;
        TimerController.time = 0f;
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
        SceneManager.LoadScene("Level2");

    }

    public void LoadLevel3()
    {
        PlayerHealth.invincibilityLength = 2f;
        PlayerHealth.isInvincible = false;
        TimerController.time = 0f;
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

    }

    public void QuitGame()
    { //To Quit Out Of The Game

        Application.Quit();

    }

    public void SettingsMenu()
    {

        SceneManager.LoadScene("SettingMenu");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");

    }

}
