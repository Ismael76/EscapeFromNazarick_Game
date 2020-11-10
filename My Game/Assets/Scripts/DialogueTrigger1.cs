using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;

    void OnTriggerEnter(Collider other)
    {

        Destroy(panel1);
        panel2.SetActive(true);
        PlayerController jump = other.GetComponent<PlayerController>();
        jump.jumpForce = 15f;


    }
}
