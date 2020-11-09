using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed; //The Speed Of The Players Movement

    public float jumpForce; //The Players Jumping Prowess

    public CharacterController controller;

    public static Vector3 moveDirection; //Player Movement

    public float gravityScale; //Scale Of The Gravity Force On The Player

    public Animator characterAnim; //Used For Certain Animations Of The Character

    public Transform piv; //Camera Pivot

    public float rotationSpeed; //Rotation Speed Of The Player

    public GameObject player; //Player Object/Model

    public float knockBackPower; //Power Of The Knockback Force On The Player (How Far They Are Knocked Back)
    public float knockBackTime; //How Far Character Should Be Knocked Back Based On Time (How Long They Are In The Air)
    private float knockBackCounter; //Knockback Counter Used To Check If Player Is Not Already Knocked Back & How Long They Should Be Knocked Back For

    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); //Inbuilt Graphity Physics On Movement Of The Player
        controller.Move(moveDirection * Time.deltaTime); //Moves Character Using Character Controller & The Vectors Given With 'moveDirection' Variable

        //Character Animations Depending On Character Positioning/Actions
        characterAnim.SetBool("isGrounded", controller.isGrounded);
        characterAnim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        if (knockBackCounter <= 0)
        {


            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")); //Movement Of Character
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            //If Player Is On The Ground, Then When They Jump The Player Should Jump With The Force They Are Given
            if (controller.isGrounded)
            { 

                moveDirection.y = 0; 

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
}