using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMapDeath : MonoBehaviour
{

    public int damageDealt = 5;
    public static bool playerIsOffMap;

    //If Players Jump Off The Map Or Fall Off, They Will Be Dealt Maximum Damage Which Is Triggered By Falling Off
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<PlayerHealth>().PlayerDamaged(damageDealt, hitDirection);
            playerIsOffMap = true;
        }

    }
}
