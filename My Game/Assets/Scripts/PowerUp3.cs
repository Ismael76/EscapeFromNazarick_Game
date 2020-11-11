using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp3 : MonoBehaviour
{

    public GameObject pickUpEffect;
    public GameObject bottleEffect1;
    public GameObject bottleEffect2;

    public static bool isUsingPowerUp3 = false;

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

        //Hides The Powerup, So It Can No Longer Be Obtained
        Destroy(bottleEffect1);
        Destroy(bottleEffect2);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Applies Power Up To The Player
        PlayerHealth.invincibilityLength = 15f;
        isUsingPowerUp3 = true;

        //Wait x Amount Of Seconds & Then Reverse The Powerup Effect
        yield return new WaitForSeconds(15f);
        PlayerHealth.invincibilityLength = 2f;
        isUsingPowerUp3 = false;

        //Destroys PowerUp
        Destroy(gameObject);

    }
}

