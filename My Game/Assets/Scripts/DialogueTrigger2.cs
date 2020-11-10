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
        //How To Reference An Variable Associated With The Player Object (Can Do The Same For Any Object)
        GameObject player = GameObject.Find("Player");
        PlayerController playerJump = player.GetComponent<PlayerController>();
        if (playerJump.jumpForce > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Destroy(panel2);
                Destroy(panel1);
                panel3.SetActive(true);
            }
        }

    }
}
