using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    public GameObject player;

    //Attachs The Player Position To The Moving Platform Object
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            player.transform.parent = transform; 
        }
    }

    //When The Player Moves Off The Moving Platform Object, They Are De-attached
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {

            player.transform.parent = null;
        }

    }

}
