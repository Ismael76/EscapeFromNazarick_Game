using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp3 : MonoBehaviour
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
        //Effect when power up picked up
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Apply power up to player
        PlayerController speed = player.GetComponent<PlayerController>(); //How to reference a variable/property in a different script
        speed.moveSpeed = 15f;

        //Hides the powerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x amount of seconds and then reverse powerup effect
        yield return new WaitForSeconds(5f);
        speed.moveSpeed = 7f;

        Destroy(gameObject);

    }
}

