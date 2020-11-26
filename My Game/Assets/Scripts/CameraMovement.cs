using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;

    public Vector3 cameraOffset;

    public static float rotationSpeed;

    public Transform pivot;

    public bool invertCamera;



    void Start()
    {

        //Initial Camera Position
        cameraOffset = target.position - transform.position;

        pivot.transform.position = target.transform.position;

        pivot.transform.parent = null;


        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (PauseMenu.isGamePaused == true && TutEnd.isTutFinished == false)
        {
            rotationSpeed = 0f;

        }
        else if (TutEnd.isTutFinished == true)
        {
            rotationSpeed = 0f;

        }
        else if (PlayerHealth.isGameOver == true)
        {
            rotationSpeed = 0f;
        }
        else
        {
            rotationSpeed = 5f;
        }

        pivot.transform.position = target.transform.position;


        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;

        //Gives Players The Option To Invert Their Camera
        if (invertCamera)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limiting The Up & Down Camera Rotation
        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);

        }


        //Moves Camera Based On Current Rotation Of Player & Original Camera Distance From The Player
        float yAngle = pivot.eulerAngles.y;
        float xAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - (rotation * cameraOffset);

        //If Camera Goes Below The Height Of The Player, It Will Prevent It From Going Down Even Further
        if (transform.position.y < target.position.y)
        {

            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target); //Makes The Camera Rotate & Look At Wherever The Player Is Currently
    }

    public void ChangeMouseSensitivity(float newSens)
    {

        rotationSpeed = newSens;
    }
}