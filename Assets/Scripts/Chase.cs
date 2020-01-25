/*
	Created by: Lech Szymanski
				lechszym@cs.otago.ac.nz
				Dec 29, 2015			
*/

using UnityEngine;
using System.Collections;

/* This is an example script using A* pathfinding to chase a
 * target game object*/

public class Chase : MonoBehaviour {
    public int startChaseRadius;

    public int stopChaseRadius;

    public GameObject waypoints = null;

    //true if chasing, false if not
    private bool chase;
    private bool chaseStop;

    //true = chase
    //false = follow path

	// Target of the chase
	// (initialise via the Inspector Panel)
	public GameObject target = null;

	// Chaser's speed
	// (initialise via the Inspector Panel)
	public float chaseSpeed;

	// Chasing game object must have a AStarPathfinder component - 
	// this is a reference to that component, which will get initialised
	// in the Start() method
	private AStarPathfinder pathfinder = null;
    private AStarPathfinder pathWayPoint = null;


    // Use this for initialization
    void Start () {
        chase = false;
        chaseSpeed = 0;
        chaseStop = false;
		//Get the reference to object's AStarPathfinder component
		pathfinder = transform.GetComponent<AStarPathfinder> ();
        pathWayPoint =  transform.GetComponent<AStarPathfinder>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player = target.transform.position;
        Vector2 waypoint = waypoints.transform.position;
        if (chase == false && Mathf.Sqrt(Mathf.Pow(player.x - transform.position.x, 2) + Mathf.Pow(player.y - transform.position.y, 2)) < startChaseRadius)
        {
            chase = true;
            chaseSpeed = 2;
            FollowPath.followPath = false;
        }
        else if(chase == true && Mathf.Sqrt(Mathf.Pow(player.x - transform.position.x, 2) + Mathf.Pow(player.y - transform.position.y, 2)) > stopChaseRadius)
        {
            chaseStop = true;
            chaseSpeed = 0;
            pathfinder.GoTowards(waypoints, 2);
            if (Mathf.Sqrt(Mathf.Pow(waypoint.x - transform.position.x, 2) + Mathf.Pow(waypoint.y - transform.position.y, 2)) < 1)
            {
                Debug.Log("reached waypoint");
                FollowPath.followPath = true;
                chase = false;
                chaseStop = false;
            }
        }
        if (pathfinder != null && chaseStop == false)
        {
            //Travel towards the target object at certain speed.
            pathfinder.GoTowards(target, chaseSpeed);
        }
    }
}
