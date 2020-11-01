using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth; //Player max health
    public int playerHealth; //Player current health

    public PlayerController player;

    public float invincibilityLength; //How long player should be invicible when damaged
    private float invincibilityCounter; //Used to count down invincibility

    public Renderer playerRenderer;
    private float flashCounter; //Used to count down player object flash when damaged
    public float flashLength = 0.2f; //Length of flash

    private bool isRespawning; //Check if player is respawning
    private Vector3 respawnPoint; //Respawn point on the map for the player

    public float respawnLength; //Length of the respawn

    void Start()
    {
        playerHealth = maxHealth; //Sets current health to max health at the start of the game

        respawnPoint = player.transform.position; //Respawn point will be where the player starts off when the game starts

    }


    void Update()
    {
        //Checks if player is invincible, if it is it will prevent damage and show player object model flashing, else it will damage the player and lead to play object model flashing to show it has been damaged
        if (invincibilityCounter > 0)
        {

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

    //When player gets damaged it will reduce current health and then knockback player whilst taking into account the player object flash to show it has been damaged
    public void PlayerDamaged(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            playerHealth -= damage;

            if (playerHealth <= 0)
            {
                Respawn(); //When player health reaches 0 it will respawn the player

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

    //If player is respawning
    public void Respawn()
    {

        if (!isRespawning)
        {

            StartCoroutine("RespawnCo");
        }
    }

    //Player will be reset back to respawn point, player model will be inactive when it dies and reactive when it respawns
    public IEnumerator RespawnCo()
    {
        GameObject player = GameObject.Find("Player");
        CharacterController charController = player.GetComponent<CharacterController>();

        isRespawning = true;
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;
        player.gameObject.SetActive(true);

        charController.enabled = false;
        player.transform.position = respawnPoint;
        charController.enabled = true;
        playerHealth = maxHealth;


        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
    }

    //Restores health of player
    public void RestoreHealth(int healAmount)
    {

        playerHealth += healAmount;

        if (playerHealth > maxHealth)
        {

            playerHealth = maxHealth;
        }
    }
}
