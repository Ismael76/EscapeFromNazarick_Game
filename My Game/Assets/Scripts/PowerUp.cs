using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;

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
        player.transform.localScale *= 1.4f;

        //Hides The Powerup, So It Can No Longer Be Obtained
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x Amount Of Seconds & Then Reverse The Powerup Effect
        yield return new WaitForSeconds(5f);
        player.transform.localScale /= 1.4f;
        
        //Destroys PowerUp
        Destroy(gameObject);

    }
}
