using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public int damageDealt = 1; //How Much Damage NPC's Deal

    public GameObject playerHitSoundEffect;


    //If Player Collides With NPC They Will Be Dealt Damage & Knocked Back In The Direction They Were Damaged
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealth.isInvincible == false) {
                playerHitSoundEffect.GetComponent<AudioSource>().Play();
            }

            if (PowerUp3.isUsingPowerUp3 == true)
            {
                return;
            }
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<PlayerHealth>().PlayerDamaged(damageDealt, hitDirection);
        }


    }
}
