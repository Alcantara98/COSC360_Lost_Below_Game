using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    Transform player;
    Vector2 offset;
    public float grabRadius = 3.0f;
    public GameObject grid;
    PlayerPhysicsWithFlip playerScript;
    Vector3 previousPos;
    float updateTimer = 30;
    // AstarPath StarGrid;
    float origionalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position;
        // Gets Components and sets Player by looking for "Player" in game objects
        player = GameObject.Find("Player").transform;
        //grid = GameObject.Find("Grid").GetComponent<AstarPath>();
        // disables the joint to the boulder by default
        // StarGrid = grid.GetComponent<AstarPath>();
        playerScript = player.GetComponent<PlayerPhysicsWithFlip>();

    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer <= 0 && previousPos != transform.position && grid != null)
        {
            grid.GetComponent<AStarGrid>().CreateMap();
            updateTimer = 20;
            previousPos = transform.position;
        }
        else
        {
            updateTimer--;
        }

    }
}
