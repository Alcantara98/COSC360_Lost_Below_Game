using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{

    List<Rigidbody2D> objects = new List<Rigidbody2D>();
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Rigidbody2D item in objects)
        {
            item.AddForce(transform.up * currentSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter collider");
        if (collision.tag == "Player")
        {
            objects.Add(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objects.Remove(collision.gameObject.GetComponent<Rigidbody2D>());
    }

}
