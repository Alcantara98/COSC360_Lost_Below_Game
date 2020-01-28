using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    public static float speed;
    //public float speedWithBoulder;
    //private float chosenSpeed;
    public float initialCurrent;
    public Rigidbody2D player;
    
    public float currentSpeed;
    private Vector2 direction = Vector2.zero;
    private Vector2 movement;


    private void Start()
    {
        speed = 1000;
        //chosenSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);
        player.AddForce(movement * speed * Time.deltaTime);

    }

    //private void OnTriggerEnter2D(Collider2D boulder)
    //{
    //    if(boulder.tag == "BoulderSquare")
    //    {
    //        chosenSpeed = speedWithBoulder;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D boulder)
    //{
    //    if(boulder.tag == "BoulderSquare")
    //    {
    //        chosenSpeed = speed;
    //    }
    //}
} 