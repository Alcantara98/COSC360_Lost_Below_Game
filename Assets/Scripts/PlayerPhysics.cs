using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Vector2 movement;
    public float boostSpeed;
    public float boostCooldown;
    float bTimer;
    public float speed = 1500;
    Rigidbody2D player;
    //public OxygenMaster oxygen;


    private void Start()
    {
        bTimer = 1.0f;
        player = transform.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (bTimer > 0)
        {
            bTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && bTimer <= 0) {
            Vector2 facing = player.velocity.normalized;
            player.AddForce(facing * boostSpeed);
            bTimer = boostCooldown;
            Debug.Log("Boosted");
        }

        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);
        player.AddForce(movement * speed * Time.deltaTime);
    }

}
