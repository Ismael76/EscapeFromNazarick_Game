using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
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
        PlayerController jump = player.GetComponent<PlayerController>(); //How to reference a variable/property in a different script
        jump.jumpForce = 30f;

        //Hides the powerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x amount of seconds and then reverse powerup effect
        yield return new WaitForSeconds(5f);
        jump.jumpForce = 15f;

        Destroy(gameObject);

    }
}
