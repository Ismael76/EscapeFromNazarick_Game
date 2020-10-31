using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    public GameObject player1;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player1)
        {

            player1.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player1)
        {

            player1.transform.parent = null;
        }

    }

}
