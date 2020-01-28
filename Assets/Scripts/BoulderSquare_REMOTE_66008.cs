using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoulderSquare : MonoBehaviour
{
    public Transform playerTransform;
    private float xOffset;
    private bool draggingBoulder;
    PlayerPhysics pp = new PlayerPhysics();

    private void Start()
    {
        xOffset = 0;
        draggingBoulder = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(playerTransform.position.x - this.transform.position.x) < 4 && Math.Abs(playerTransform.position.y - this.transform.position.y) < 4)
        {
            
            pp.speed = 400;

            if (Input.GetMouseButtonDown(0))
            {
                //this.transform.position = new Vector2(0, 0);
                xOffset = playerTransform.position.x - this.transform.position.x;
                draggingBoulder = true;
            }

            if (Input.GetMouseButton(0) && draggingBoulder == true)
            {
                this.transform.position = new Vector2(playerTransform.position.x - xOffset, this.transform.position.y);
            }
        }
        if (Math.Abs(playerTransform.position.x - this.transform.position.x) > 4 || Math.Abs(playerTransform.position.y - this.transform.position.y) > 4)
        {
            draggingBoulder = false;
        }
    }
}
