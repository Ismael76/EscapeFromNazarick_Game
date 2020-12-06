using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp3 : MonoBehaviour
{

    public GameObject pickUpEffect;
    public GameObject bottleEffect1;
    public GameObject bottleEffect2;

    public static bool isUsingPowerUp3 = false;

    public GameObject powerUpSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(PickUp(other));
        }
    }
    IEnumerator PickUp(Collider player)
    {
        
        //Effect When Power Up Is Picked Up
        Instantiate(pickUpEffect, transform.position, transform.rotation);
        powerUpSound.GetComponent<AudioSource>().Play();

        //Applies Power Up To The Player
        PlayerHealth.isInvincible = true;
        isUsingPowerUp3 = true;
        PlayerHealth.invincibilityLength = 15f;

        //Hides The Powerup, So It Can No Longer Be Obtained
        Destroy(bottleEffect1);
        Destroy(bottleEffect2);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x Amount Of Seconds & Then Reverse The Powerup Effect
        yield return new WaitForSeconds(15f);
        isUsingPowerUp3 = false;
        PlayerHealth.isInvincible = false;
        PlayerHealth.invincibilityLength = 2f;

        //Destroys PowerUp
        Destroy(gameObject);

    }
}

