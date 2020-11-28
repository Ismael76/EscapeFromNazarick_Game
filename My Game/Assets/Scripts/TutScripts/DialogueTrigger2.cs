using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{

    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel6;
    public GameObject panel5;
    public GameObject panel4;
    public GameObject panel3;
    public GameObject panel2;
    public GameObject panel1;

    void Update()
    {
        if (panel3 == null) {
            return;
        }
        //How To Reference An Variable Associated With The Player Object (Can Do The Same For Any Object)
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerJump = player.GetComponent<PlayerMovement>();
        if (playerJump.jumpForce > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Destroy(panel2);
                Destroy(panel1);
                panel3.SetActive(true);
            }
        }

        if (panel1 == null) { 
           return;
        }
    }
}
