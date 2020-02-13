using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints = null;

    public GameObject player;
    public float idleSpeed = 2;
    public float chaseSpeed = 3;

    // radius to start and stop chasing player
    public float startChaseRadius = 8;
    public float stopChaseRadius = 15;
    AIDestinationSetter destinationScript;
    AIPath path;
    private bool rightFacing = false;
    public float moveOnDistance = 1;

    enum Behaviour
    {
        ChasePlayer,
        FollowPoints
    }
    Behaviour currentBehaviour;
    int waypointIndex;
    Transform target;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        currentBehaviour = Behaviour.FollowPoints;
        target = GameObject.Find("Player").transform;
        destinationScript = transform.GetComponent<AIDestinationSetter>();
        destinationScript.target = waypoints[waypointIndex];
        path = transform.GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.rotation.eulerAngles.z > 10 && transform.rotation.eulerAngles.z < 170 && rightFacing)
        {
            this.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            rightFacing = false;
        }
        else if (transform.rotation.eulerAngles.z > 190 && transform.rotation.eulerAngles.z < 350 && !rightFacing)
        {
            this.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            rightFacing = true;

        }
        if (Vector2.Distance(waypoints[waypointIndex].position, transform.position) < moveOnDistance && currentBehaviour == Behaviour.FollowPoints)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            destinationScript.target = waypoints[waypointIndex];
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
            currentBehaviour = Behaviour.FollowPoints;
            path.maxSpeed = idleSpeed;
            destinationScript.target = waypoints[waypointIndex];
        }
    }

    
    

}
