using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int playerHealth;

    public PlayerController player;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.2f;

    private bool isRespawning;
    private Vector3 respawnPoint;

    public float respawnLength;

    void Start()
    {
        playerHealth = maxHealth;

        respawnPoint = player.transform.position; //Respawn point will be where the player starts off when the game starts

    }


    void Update()
    {
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

    public void PlayerDamaged(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            playerHealth -= damage;

            if (playerHealth <= 0)
            {
                Respawn();

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

    public void Respawn()
    {

        if (!isRespawning)
        {

            StartCoroutine("RespawnCo");
        }
    }

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

    public void RestoreHealth(int healAmount)
    {

        playerHealth += healAmount;

        if (playerHealth > maxHealth)
        {

            playerHealth = maxHealth;
        }
    }
}
