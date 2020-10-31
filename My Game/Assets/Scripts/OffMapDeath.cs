using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMapDeath : MonoBehaviour
{

    public int damageDealt = 100;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<PlayerHealth>().PlayerDamaged(damageDealt, hitDirection);
        }

    }
}
