using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    RelativeJoint2D joint;
    Transform player;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Gets Components and sets Player by looking for "Player" in game objects
        joint = transform.GetComponent<RelativeJoint2D>();
        player = GameObject.Find("Player").transform;

        // disables the joint to the boulder by default
        joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        // When player is close enough to boulder and presses button, enables joint and keeps it
        // at current offset. Disables joint again when button released
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(player.position, transform.position) < 1.4)
        {
            joint.linearOffset = player.position - transform.position;
            joint.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
        }
    }
}
