using UnityEngine;

public class FollowPath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    public float speed;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    //speed of roation
    public float turnSpeed;

    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        //transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        // Move Enemy
        Move();
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        if (waypoints != null)
        {
            // If Enemy didn't reach last waypoint it can move
            // If enemy reached last waypoint then it stops
            if (waypointIndex <= waypoints.Length - 1)
            {
                Vector2 wayPointPosition = new Vector2(waypoints[waypointIndex].position.x, waypoints[waypointIndex].position.y);
                Vector2 alienPosition = new Vector2(transform.position.x, transform.position.y);
                Vector2 difference = alienPosition - wayPointPosition;

                float targetAngle = Vector2.Angle(Vector2.up, difference);

                if (difference.x > 0)
                {
                    targetAngle = targetAngle * -1;
                }

                transform.rotation = Quaternion.Slerp(transform.rotation,
                                Quaternion.Euler(0, 0, targetAngle),
                                turnSpeed * Time.deltaTime);

                transform.Translate(Vector3.down * speed * Time.deltaTime);

                // Move Enemy from current waypoint to the next one
                // using MoveTowards method
                /*transform.position = Vector2.MoveTowards(transform.position,
                   waypoints[waypointIndex].transform.position,
                   moveSpeed * Time.deltaTime);
                */


                // If Enemy reaches position of waypoint he walked towards
                // then waypointIndex is increased by 1
                // and Enemy starts to walk to the next waypoint
                /*if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
                */
            }
            else
            {
                waypointIndex = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D waypoint)
    {
        Debug.Log("Hello");
        if (waypoint.gameObject.tag == "Waypoint")
        {
            waypointIndex += 1;
            Debug.Log("Hello");
        }
    }
}