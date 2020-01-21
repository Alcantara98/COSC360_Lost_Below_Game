using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public static bool followPath;
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints = null;

    public float speed;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    //speed of roation
    public float turnSpeed;

    // Use this for initialization
    private void Start()
    {
        followPath = true;
        // Set position of Enemy as position of the first waypoint
        //transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (followPath == true)
        {
            // Move Enemy
            Move();
        }
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
                                Quaternion.Euler(0, 0, targetAngle + 90),
                                turnSpeed * Time.deltaTime);

                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                waypointIndex = 0;
            }
        }
    }

    // if current waypoint is reached, move to the next one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Waypoint")
        {
            waypointIndex += 1;
        }
    }
}