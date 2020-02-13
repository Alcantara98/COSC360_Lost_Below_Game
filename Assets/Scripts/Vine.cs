using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("yes it works");
                Destroy(gameObject);
            }

        }
    }
}