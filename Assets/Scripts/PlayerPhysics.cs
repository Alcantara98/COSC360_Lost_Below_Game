using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    public float speed;
    public float initialCurrent;
    public Rigidbody2D player;
    public float currentSpeed;
    private Vector2 direction = Vector2.zero;
    private Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);
        player.AddForce(movement * speed * Time.deltaTime);


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

        if (direction != Vector2.zero)
        {
            player.AddForce(direction * currentSpeed * Time.deltaTime);
        }


        //    transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Current")
        {
            direction = collision.transform.up;
            //player.AddForce(direction * initialCurrent);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Current")
        {
            direction = Vector2.zero;

        }
    }
}
