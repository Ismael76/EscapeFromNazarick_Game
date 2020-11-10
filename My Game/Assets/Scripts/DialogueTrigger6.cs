using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger6 : MonoBehaviour
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

        Destroy(panel6);
        Destroy(panel5);
        Destroy(panel4);
        Destroy(panel3);
        Destroy(panel2);
        Destroy(panel1);
        panel7.SetActive(true);


    }
}
