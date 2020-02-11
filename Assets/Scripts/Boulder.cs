using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    RelativeJoint2D joint;
    Transform player;
    Vector2 offset;
    public float grabRadius = 3.0f;
    public GameObject grid;
    PlayerPhysics playerScript;

    Vector3 previousPos;
    float updateTimer = 30;
    AstarPath StarGrid;

    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position;
        // Gets Components and sets Player by looking for "Player" in game objects
        joint = transform.GetComponent<RelativeJoint2D>();
        player = GameObject.Find("Player").transform;
        //grid = GameObject.Find("Grid").GetComponent<AstarPath>();
        // disables the joint to the boulder by default
        joint.enabled = false;
        StarGrid = grid.GetComponent<AstarPath>();
        playerScript = player.GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer <= 0 && previousPos != transform.position)
        {
            StarGrid.Scan();
            updateTimer = 20;
            previousPos = transform.position;
        } else
        {
            updateTimer--;
        }


        // When player is close enough to boulder and presses button, enables joint and keeps it
        // at current offset. Disables joint again when button released
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(player.position, transform.position) < grabRadius)
        {
            joint.linearOffset = player.position - transform.position;
            joint.enabled = true;
            playerScript.pullingBoulder = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            playerScript.pullingBoulder = false;
        }
    }
}
