using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damageDealt = 50; //Damage dealing amount for current NPC


    void OnTriggerEnter(Collider other) //When collision between the specified object happens trigger an event
    {
        if (other.CompareTag("Player")) //Checks if the object we are talking about is the object with a tag called 'Player'
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<PlayerHealth>().PlayerDamaged(damageDealt, hitDirection); //If player gets damaged the character will be dealt the damage and will be moved in the direction it was damaged from
        }


    }
}
