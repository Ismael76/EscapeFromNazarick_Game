using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth; //The Players Maximum Health They Can Attain
    public int playerHealth; //The Players Current Health In Game

    public int numOfHearts; //The Players Hearts Which Indicates The Amount Of Health They Have

    public Image[] hearts; //Array Used To Count Hearts
    public Sprite fullHeart, emptyHeart; //Sprites Used To Represent Hearts

    public PlayerController player;

    public float invincibilityLength; //How Long The Player Should Be Invincible For When Damaged
    private float invincibilityCounter; //Used To Count Down The Players Invincibility Time

    public Renderer playerRenderer;
    private float flashCounter; //Used To Count Down How Long The Player Object Should Be Flashed When Damaged To Create A Damage Effect
    public float flashLength = 0.2f; //The Length Of The Flash

    private bool isRespawning; //Used To Check If Player Is Respawning
    private Vector3 respawnPoint; //Respawn Point For The Player

    public float respawnLength = 1; //Length Of The Respawn

    public GameObject gameOver;
    public static bool isGameOver;

    void Start()
    {
        maxHealth = 5;
        
        playerHealth = maxHealth; //Setting Player Health To Maximum Health When The Game Begins

        respawnPoint = player.transform.position; //Positioning Player At The Respawn Point When Game Begins

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

                }

            }

    }

    public void GameOver(){

        gameOver.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        Cursor.lockState = CursorLockMode.None;

    }

    //If The Player Is Respawning
    /*public void Respawn()
    {

        if (!isRespawning)
        {

            StartCoroutine("RespawnCo");
        }
    }

    //Player Will Be Reset Back To Respawn Point, Player Model Will Be Inactive When They Die & Will Only Reactivate When They Respawn
    public IEnumerator RespawnCo()
    {
        GameObject player = GameObject.Find("Player");
        CharacterController charController = player.GetComponent<CharacterController>();
    
        isRespawning = true;
        player.gameObject.SetActive(true);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        charController.enabled = false;
        player.transform.position = respawnPoint;
        charController.enabled = true;
        playerHealth = maxHealth;


        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;

    } */

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