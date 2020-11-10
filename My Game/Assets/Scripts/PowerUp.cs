using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;
    public GameObject bottleEffect1;
    public GameObject bottleEffect2;

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

        //Applies Power Up To The Player
        PlayerHealth health = player.GetComponent<PlayerHealth>(); //How To Reference A Variable/Property In A Different Script
        health.maxHealth = 10;
        health.playerHealth = 10;
        health.numOfHearts = 10;


        //Hides The Powerup, So It Can No Longer Be Obtained
        Destroy(bottleEffect1);
        Destroy(bottleEffect2);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x Amount Of Seconds & Then Reverse The Powerup Effect
        yield return new WaitForSeconds(5f);
        health.maxHealth = 5;
        health.playerHealth = 5;
        health.numOfHearts = 5;
        
        //Destroys PowerUp
        Destroy(gameObject);

    }
}
