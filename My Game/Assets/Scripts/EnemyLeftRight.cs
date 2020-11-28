using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftRight : MonoBehaviour
{
    public Transform[] waypoints;

    public int speed;

    private int waypointIndex;
    private float dist;

    void Start()
    {

        //Enemy Starts Of At First Waypoint & Faces Waypoints
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);

    }

    void Update()
    {

        //Checks Distance Between Enemy & Waypoint
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (dist < 1f)
        {

            IncreaseIndex();
        }

        Patrol();
    }

    //Moves Enemy Towards Waypoints
    void Patrol()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //Increase Index Of Waypoint Array & Making Sure Its Not Out Of Bounds
    void IncreaseIndex()
    {

        waypointIndex++;

        if (waypointIndex >= waypoints.Length)
        {

            waypointIndex = 0;

        }

        transform.LookAt(waypoints[waypointIndex].position);
    }
}

