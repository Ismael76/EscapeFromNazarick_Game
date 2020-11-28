using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel6;
    public GameObject panel5;
    public GameObject panel4;
    public GameObject panel3;
    public GameObject panel2;
    public GameObject panel1;


    void OnTriggerEnter(Collider other)
    {

        if (panel2 == null) { 
            return;
        }
        
        Destroy(panel1);
        panel2.SetActive(true);
        PlayerMovement playerJump = other.GetComponent<PlayerMovement>();
        playerJump.jumpForce = 15f;

    }
}
