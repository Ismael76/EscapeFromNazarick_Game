using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int playerHealth; 

    public int numOfHearts; 

    public Image[] hearts; 
    public Sprite fullHeart, emptyHeart; 

    public PlayerMovement player;

    public static float invincibilityLength = 2f; 
    public static float invincibilityCounter;
    public static bool isInvincible = false;

    public Renderer playerRenderer;
    private float flashCounter; 
    public float flashLength = 0.2f; 


    public GameObject gameOver;
    public GameObject gameOver2;
    public static bool isGameOver;

    void Start()
    {
        //Setting Players Health When Game Starts
        maxHealth = 5;
        
        playerHealth = maxHealth;

    }


    void Update()
    {
        if (playerHealth > numOfHearts) {
                playerHealth = numOfHearts;
        }
            // This Part Of The Code Checks Players Health With The Hearts Displayed On Screen To Represent Correct Health
            for (int i = 0; i < hearts.Length; i++)
                {
                    //If Players Health Is Less Than The Number Of Hearts In The Array, Show Red Hearts That Correspond To Players Health, The Other Hearts In Array Will Be Grey (To Show Player Lost Health)
                    if (i < playerHealth) {
                        hearts[i].sprite = fullHeart;
                    } else {
                        hearts[i].sprite = emptyHeart;
                    }
                    //Will Show All Hearts In Array Until The Maximum Number Of Hearts Array Is Reached
                    if (i < numOfHearts) {
                        hearts[i].enabled = true;
                    } else {
                         hearts[i].enabled = false;

                    }
                }
        //This Checks If The Player Is Invincible, If They Are, It Will Prevent Further Damage & Show Player Object Model Flashing, Else It Will Damage The Player & Also Flashing The Player To Show Damage Dealt
        if (invincibilityCounter > 0)
        {
            if (OffMapDeath.playerIsOffMap == true){
                GameOver();
            }

            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0)
            {

                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;

            }

            if (invincibilityCounter <= 0)
            {

                playerRenderer.enabled = true;
                isInvincible = false;

            }
        }
    }

    //When The Player Gets Damaged It Will Reduce Current Health & Then Knockback The Player
    public void PlayerDamaged(int damage, Vector3 direction)
    {

        if (invincibilityCounter <= 0)
        {
            playerHealth -= damage;

            if (playerHealth <= 0)
            {

                GameOver();

            }

            else
            {

                player.KnockBack(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCounter = flashLength;

                isInvincible = true;

                }
                
            }

    }

    public void GameOver(){

        gameOver.SetActive(true);
        invincibilityLength = 2f;
        Time.timeScale = 0f;
        isGameOver = true;
        isInvincible = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void GameOver2(){

        gameOver2.SetActive(true);
        invincibilityLength = 2f;
        Time.timeScale = 0f;
        isGameOver = true;
        isInvincible = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    
    //Restoring The Health Of The Player
    public void RestoreHealth(int healAmount)
    {

        playerHealth += healAmount;

        if (playerHealth > maxHealth)
        {

            playerHealth = maxHealth;
        }
    }
}