using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public int vineLifeInt = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter collider");
        if (collision.gameObject.tag == "Player")
        {
            vineLifeInt--;
            Debug.Log(vineLifeInt);
            if (vineLifeInt == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    objects.Remove(collision.gameObject.GetComponent<Rigidbody2D>());
    //}
}
