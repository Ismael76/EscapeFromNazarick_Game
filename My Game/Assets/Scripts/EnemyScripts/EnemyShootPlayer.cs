using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootPlayer : MonoBehaviour
{
    public Transform player;

    public Transform projectile;

    public static Animator anim;

    public Collider other;

    public int skeletonDamage = 2;

    private float shotTime = 0;
    public float timeBetweenShot = 0.5f;

    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        //Works Out Direction From Player To Skeleton
        Vector3 direction = player.position - this.transform.position;

        //If Player Is Within Vision
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 180)
        {
            direction.y = 0;

            //Use Direction To Make Skeleton Rotate Towards Player
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);

            anim.SetBool("isIdle", false);

            //Move Enemy Towards Player & Plays Correct Animation
            if (direction.magnitude <= 10 && (Time.time - shotTime) > timeBetweenShot)
            {

                this.transform.Translate(0, 0, 0);
                Shoot();
                anim.SetBool("isAttacking", true);

            }
            else
            {
                anim.SetBool("isAttacking", false);

            }

        }
        else
        {

            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
        }

    }

    public void Shoot()
    {
        shotTime = Time.time;
        Instantiate(projectile, transform.position + (player.position - transform.position).normalized, Quaternion.LookRotation(player.position - transform.position));
    }
}
