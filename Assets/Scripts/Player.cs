using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float movementInput = Input.GetAxis("Horizontal");

        float updownInput = Input.GetAxis("Vertical");

        /**
        // If close to wall and moving towards it,
        // stop the movment
        if (atLeftWall && (movementInput < 0))
        {
            movementInput = 0;
        }
        if (atRightWall && (movementInput > 0))
        {
            movementInput = 0;
        }
    */

        // Move the player object
        transform.Translate(new Vector3(Time.deltaTime * speed * movementInput, Time.deltaTime * speed * updownInput, 0));
    }
}
