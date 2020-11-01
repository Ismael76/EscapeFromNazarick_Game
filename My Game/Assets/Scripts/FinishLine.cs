using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject endScrn;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endScrn.gameObject.SetActive(true); //Once player reaches the end the end screen will be shown

        }


    }
}
