using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    public Transform player;

    public static Animator anim;

    public Collider other;
    
    public int skeletonDamage = 2;

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

        if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 180) 
        {
            direction.y = 0;

            //Use Direction To Make Skeleton Rotate Towards Player
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);

            anim.SetBool("isIdle", false);

            //Move Enemy Towards Player & Plays Correct Animation
            if(direction.magnitude > 1) {

                this.transform.Translate(0, 0, 0.09f);
                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", false);

            } else {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isRunning", false);
                
            } 

        } else {

            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
        }
        
    }

    public void AttackEnd() {

        Vector3 hitDirection = other.transform.position - transform.position;
        hitDirection = hitDirection.normalized;
        FindObjectOfType<PlayerHealth>().PlayerDamaged(skeletonDamage, hitDirection);
    }
}
