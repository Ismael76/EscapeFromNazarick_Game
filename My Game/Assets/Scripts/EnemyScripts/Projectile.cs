using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject skeletonMageHitSound;

    public int skeletonMageDamage = 3;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            Destroy(gameObject);

            if (PlayerHealth.isInvincible == false)
            {

                skeletonMageHitSound.GetComponent<AudioSource>().Play();
                Vector3 hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;
                FindObjectOfType<PlayerHealth>().PlayerDamaged(skeletonMageDamage, hitDirection);
                Destroy(gameObject);
            }

            if (PowerUp3.isUsingPowerUp3 == true)
            {
                skeletonMageHitSound.GetComponent<AudioSource>().Stop();
                Destroy(gameObject);
            }

        }

        if (other.CompareTag("Ground")) {

            Destroy(gameObject);
        }
    }
}
