using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed; //Player movement speed

    public float jumpForce; //Player jumping ability

    public CharacterController controller; //Controller used for player movement

    public static Vector3 moveDirection; //Player movement

    public float gravityScale; //Scale of gravity force on player, Vector3 uses x, y & z coordinates of objects

    public Animator characterAnim;

    public Transform piv;

    public float rotationSpeed;

    public GameObject player;

    public float knockBackPower;
    public float knockBackTime;
    private float knockBackCounter;

    //Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();

    }

    //Update is called once per frame
    void Update()
    {

        if (knockBackCounter <= 0)
        {


            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")); //transform.forward will move the object forward based on direction it is facing, transform.right moves character left or right 
            moveDirection = moveDirection.normalized * moveSpeed; //Normalized smoothens the movement when the character is moving diagonally so moving forward and right, forward and left, backwards and right, backwards and left at the same time
            moveDirection.y = yStore;

            if (controller.isGrounded)
            { //Checks if player is on the ground

                moveDirection.y = 0; //Sets gravity to 0 if player is on the ground

                if (Input.GetButtonDown("Jump"))
                {

                    moveDirection.y = jumpForce;

                }

            }
        }
        else
        {

            knockBackCounter -= Time.deltaTime;

        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); //Physics.gravity is the default gravity physics built into unity
        controller.Move(moveDirection * Time.deltaTime); //Moves character using character controller and the vectors given with moveDirection variable

        characterAnim.SetBool("isGrounded", controller.isGrounded);
        characterAnim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        //Player movement in different direction following camera direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            transform.rotation = Quaternion.Euler(0, piv.rotation.eulerAngles.y, 0);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

        }

    }

    public void KnockBack(Vector3 knockbackDirection) //Knocks back player when it runs into an enemy or object that is dangerous
    {

        knockBackCounter = knockBackTime;

        moveDirection = knockbackDirection * knockBackPower;

        moveDirection.y = knockBackPower;

    }
}
