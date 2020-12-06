using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttach : MonoBehaviour
{
    public GameObject npc;

    //Attachs The Player Position To The Moving Platform Object
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == npc)
        {
            npc.transform.parent = this.transform;

        }
    }

    //When The Player Moves Off The Moving Platform Object, They Are De-attached
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == npc)
        {

            npc.transform.parent = null;
        }

    }
}
