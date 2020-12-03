using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public static int damageDealt = 1; //How Much Damage NPC's Deal

    public GameObject playerHitSoundEffect;

    public static bool isDamaged = false;

    //If Player Collides With NPC They Will Be Dealt Damage & Knocked Back In The Direction They Were Damaged
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDamaged = true;
            if (isDamaged == true) {
                if (PlayerHealth.isInvincible == false) {
                    playerHitSoundEffect.GetComponent<AudioSource>().Play();
                }

                if (PowerUp3.isUsingPowerUp3 == true)
                {
                    playerHitSoundEffect.GetComponent<AudioSource>().Stop();
                    return;
                }
                Vector3 hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;
                FindObjectOfType<PlayerHealth>().PlayerDamaged(damageDealt, hitDirection);
            }
        } else {

            isDamaged = false;
        }

    }
}
