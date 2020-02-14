using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseBoulder : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Boulder;
    private float gravity;
    void Start()
    {
        gravity = Boulder.gravityScale;
        Boulder.gravityScale = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("@@@@@@@@@@@@@@");
            Boulder.gravityScale = gravity;
        }
    }
}
