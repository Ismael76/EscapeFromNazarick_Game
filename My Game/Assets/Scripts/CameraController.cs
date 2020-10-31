using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; //Target of the camera, what the camera is focussed on, 'Transfrom' is a component attached to every game object which provides info such as scale, position of an object etc...

    public Vector3 cameraOffset; //Used to move the camera to follow the players movements

    public float rotationSpeed; //Rotate camera around player

    public Transform pivot; //Sub Camera set around the player object

    public bool invertCamera;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = target.position - transform.position; //Subtracting player position from cameras current position given by (transform.position)

        pivot.transform.position = target.transform.position; //Moves pivot to where the player is

        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked; //Hides cursor when game starts, locks it at the center of the screen
    }

    // Update is called once per frame
    void LateUpdate() //Late update moves everything after the update, so since we want out player to move first and camera follow suite we want camera to update just abit after our player so the camera knows where player is moving etc and it doesnt jitter
    {

        pivot.transform.position = target.transform.position; //Pivot point will move with player

        //This gets the x position of the mouse when moving it and rotates the player
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed; //Creating variable in update function so that the value is not constant rather it updates with every frame, Mouse X is the mouse movement on the X axis
        pivot.Rotate(0, horizontal, 0);

        //Gets y position of mouse and rotates the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;

        //Gives players the option to invert their camera
        if (invertCamera)
        {
            pivot.Rotate(vertical, 0, 0); //-vertical will invert the camera
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limiting the up and down camera rotation
        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180)
        { //Adding a f after a number tells unity that this number is float
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 315f)
        { //Adding a f after a number tells unity that this number is float
            pivot.rotation = Quaternion.Euler(315f, 0, 0);

        }


        //Moves camera based on current rotation of player and original camera distance from player
        float yAngle = pivot.eulerAngles.y; //eulerAngles turns the quaternion 4 axis back into a normal vector3 axis
        float xAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - (rotation * cameraOffset);

        if (transform.position.y < target.position.y)
        { //If camera goes below the height of the player, prevent it from going down even further

            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target); //This will make the camera rotate and look at wherever our player is
    }
}
