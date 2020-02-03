using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.position.x;
        float y = player.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
