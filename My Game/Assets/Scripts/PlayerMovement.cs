using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed; 

    public float jumpForce; 

    public CharacterController controller;

    public static Vector3 moveDirection; 

    public float gravityScale; 

    public Animator characterAnim; 

    public Transform piv; 

    public float rotationSpeed; 

    public GameObject player; 

    private int dJumpCounter = 0;
    private int nrOfAlowedDJumps = 1;

    public float knockBackPower; 
    public float knockBackTime; 
    private float knockBackCounter; 

    void Start()
    {
        //CharacterController Used To Move Player Instead Of RigidBody
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); 
        controller.Move(moveDirection * Time.deltaTime); 

        //Character Animations Depending On Character Positioning/Actions
        characterAnim.SetBool("isGrounded", controller.isGrounded);
        characterAnim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        if (knockBackCounter <= 0)
        {
            //Movement Of Character
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")); 
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            //If Player Is On The Ground, Then When They Jump The Player Should Jump With The Force They Are Given
            if (controller.isGrounded)
            { 
                moveDirection.y = 0; 
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                    dJumpCounter = 0;

                }

            } else if (Input.GetButtonDown("Jump") && PowerUp2.isUsingPowerUp2 == true && !controller.isGrounded && dJumpCounter < nrOfAlowedDJumps) {

                moveDirection.y = jumpForce * 2f;
                dJumpCounter++;

            }
        } else
        {

            knockBackCounter -= Time.deltaTime;

        }

        //Player Movement In Different Direction Following Camera Direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            transform.rotation = Quaternion.Euler(0, piv.rotation.eulerAngles.y, 0);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

        }


    }

    public void KnockBack(Vector3 knockbackDirection) //Knocks Back The Player When They Run Into An Enemy Or Object That Deals Damage
    {

        knockBackCounter = knockBackTime;

        moveDirection = knockbackDirection * knockBackPower;

        moveDirection.y = knockBackPower;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit) //Platforms Given Specific Abilities
    {

        switch (hit.gameObject.tag)
        {

            case "JumpPad":
                jumpForce = 25f;
                break;
            case "SpeedPad":
                moveSpeed = 15f;
                break;
            case "Ground":
                jumpForce = 15f;
                moveSpeed = 7f;
                break;
        }


    }
}