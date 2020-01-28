using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoulderSquare : MonoBehaviour
{
    public Transform playerTransform;
    private float xOffset;
    private bool pullingBoulder;

    public Rigidbody2D boulder;

    private void Start()
    {
        boulder.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        xOffset = 0;
        pullingBoulder = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(playerTransform.position.x - this.transform.position.x) < 2 && Math.Abs(playerTransform.position.y - this.transform.position.y) < 2)
        {
            boulder.constraints = RigidbodyConstraints2D.None;
            boulder.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPhysics.speed = 200;
                //this.transform.position = new Vector2(0, 0);
                xOffset = playerTransform.position.x - this.transform.position.x;
                pullingBoulder = true;
            }

            if (Input.GetMouseButton(0) && pullingBoulder == true)
            {
                this.transform.position = new Vector2(playerTransform.position.x - xOffset, this.transform.position.y);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            boulder.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            PlayerPhysics.speed = 1000;
            pullingBoulder = false;
        }
    }
}
