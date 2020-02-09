using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public GameObject knifeIcon;
    public static bool hasKnife = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Knife")
        {
            Debug.Log(hasKnife);
            if (knifeIcon != null)
            {
                knifeIcon.SetActive(true);
                hasKnife = true;
                Debug.Log(hasKnife);
            } else if (knifeIcon == null)
            {
                Debug.Log("That piece of shit icon is not found");
            }
            Destroy(collider.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Vine")
        {

            Debug.Log(hasKnife);
            if (hasKnife)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    Destroy(collision.gameObject);
                }
            }

        }
    }
}
