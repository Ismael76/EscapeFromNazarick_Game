using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
 

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;

    void Start() {


    }


    void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse1)) {

            Destroy(panel1);

        }
    }
}
