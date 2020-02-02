using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Vector2 movement;
    public float boostSpeed = 400;
    public float boostCooldown = 2;
    float bTimer;
    public float speed = 1500;
    public float boostCost = 5;
    PlayerOxygen oxygen;
    Rigidbody2D player;
    //public OxygenMaster oxygen;


    private void Start()
    {
        bTimer = 1.0f;
        player = transform.GetComponent<Rigidbody2D>();
        oxygen = transform.GetComponent<PlayerOxygen>();
    }
    // Update is called once per frame
    void Update()
    {
        if (bTimer > 0)
        {
            bTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && bTimer <= 0)
        {
            Boost();
        }

        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);
        player.AddForce(movement * speed * Time.deltaTime);
    }

    void Boost()
    {
        if (oxygen.DecreaseOxygen(boostCost))
        {
            Vector2 facing = player.velocity.normalized;
            player.AddForce(facing * boostSpeed);
            bTimer = boostCooldown;
        }
    }

}
