using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    public GameObject player;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            player.transform.parent = transform; //Attach player position to the object
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {

            player.transform.parent = null; //When player moves off object de-attach
        }

    }

}
