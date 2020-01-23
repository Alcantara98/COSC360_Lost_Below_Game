using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    public float speed;
    public Rigidbody2D player;
    private Vector3 direction = Vector3.zero;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);
        player.AddForce(movement * speed);


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

        //            

        //    if (direction != )
        //    {
        //        movement += (direction * 5 * Time.deltaTime);
        //    }


        //    transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Current")
        {
            player.AddForce(collision.transform.up * 200);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Current")
    //    {
    //        direction = Vector2.up;

    //    }
    //}
}
