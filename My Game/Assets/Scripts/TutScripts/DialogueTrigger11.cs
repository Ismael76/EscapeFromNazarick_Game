using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger11 : MonoBehaviour
{
    public GameObject panel9;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel6;
    public GameObject panel5;
    public GameObject panel4;
    public GameObject panel3;
    public GameObject panel2;
    public GameObject panel1;
    public GameObject panel10;
    public GameObject panel11;
    public GameObject panel12;

    void OnTriggerEnter(Collider other)
    {
        if (panel12 == null)
        {
            return;
        }
        Destroy(panel9);
        Destroy(panel11);
        Destroy(panel10);
        Destroy(panel8);
        Destroy(panel7);
        Destroy(panel6);
        Destroy(panel5);
        Destroy(panel4);
        Destroy(panel3);
        Destroy(panel2);
        Destroy(panel1);
        panel12.SetActive(true);


    }
}
