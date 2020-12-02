using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 7f;
    public Animator enemyAnim;

    Transform target;

    NavMeshAgent agent;

    public GameObject enemySoundtrack;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        //Chase Player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            if (!enemySoundtrack.GetComponent<AudioSource>().isPlaying)
            {
                enemySoundtrack.GetComponent<AudioSource>().Play();
            }
            enemyAnim.SetBool("isChasingPlayer", true);
            agent.SetDestination(target.position);
            enemyAnim.SetFloat("MoveSpeed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

            if (distance <= agent.stoppingDistance)
            {
                //Attack Target
                enemyAnim.SetBool("Attack", true);

                //Face Target
                FaceTarget();
            }
            else
            {
                enemyAnim.SetBool("Attack", false);

            }
        }
        else
        {

            enemyAnim.SetBool("isChasingPlayer", false);
            enemySoundtrack.GetComponent<AudioSource>().Stop();
        }
    }

    public void AttackEnd()
    {

        //Damage Player
        Debug.Log("Hit");
    }

    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //Shows Enemy Radius
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

