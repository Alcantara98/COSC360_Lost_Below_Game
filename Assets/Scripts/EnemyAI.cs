using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints = null;

    public float idleSpeed = 2;
    public float chaseSpeed = 3;

    // radius to start and stop chasing player
    public float startChaseRadius = 8;
    public float stopChaseRadius = 15;
    AIDestinationSetter destinationScript;
    AIPath path;
    public 

    enum Behaviour
    {
        ChasePlayer,
        FollowPoints
    }
    Behaviour currentBehaviour;
    int waypointIndex;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        currentBehaviour = Behaviour.FollowPoints;
        target = GameObject.Find("Player").transform;
        destinationScript = transform.GetComponent<AIDestinationSetter>();
        destinationScript.target = waypoints[waypointIndex];
        path = transform.GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (path.reachedDestination && currentBehaviour == Behaviour.FollowPoints)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        float distance = Vector2.Distance(target.position, transform.position);
        //Debug.Log(distance);
        if (distance < startChaseRadius && currentBehaviour != Behaviour.ChasePlayer)
        {
            path.maxSpeed = chaseSpeed;
            currentBehaviour = Behaviour.ChasePlayer;
            destinationScript.target = target;
        }
        else if (distance > stopChaseRadius)
        {
            Debug.Log("entered");
            currentBehaviour = Behaviour.FollowPoints;
            path.maxSpeed = idleSpeed;
            destinationScript.target = waypoints[waypointIndex];
        }


    }
}
