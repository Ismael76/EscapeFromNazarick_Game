using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
{

    public GameObject pickUpEffect;
    public GameObject bottleEffect1;
    public GameObject bottleEffect2;

    public static bool isUsingPowerUp2 = false;

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
        isUsingPowerUp2 = true;
        
        //Hides The Powerup, So It Can No Longer Be Obtained
        bottleEffect1.SetActive(false);
        bottleEffect2.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x Amount Of Seconds & Then Reverse The Powerup Effect
        yield return new WaitForSeconds(3f);
        isUsingPowerUp2 = false;

        //Destroys PowerUp
        Destroy(gameObject);

    }
}
