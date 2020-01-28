using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float speed = 1500;

    Rigidbody2D rb;
    Vector2 movement;
    //public OxygenMaster oxygen;


    private void Start()
    {
        // sets rigidbody
        rb = transform.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);
        rb.AddForce(movement * speed * Time.deltaTime);
    }

}
