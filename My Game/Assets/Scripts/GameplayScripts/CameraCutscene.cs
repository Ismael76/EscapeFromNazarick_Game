using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutscene : MonoBehaviour
{

    public GameObject camera;

    public GameObject gameText;

    void Start()
    {

        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene()
    {
        
        yield return new WaitForSeconds(4f);
        camera.SetActive(false);


        yield return new WaitForSeconds(8f);
        gameText.SetActive(false);
    }
}
