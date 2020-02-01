using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collectibles : MonoBehaviour
{
    public GameObject knifeIcon;
    public static bool hasKnife = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (knifeIcon != null && gameObject.tag == "Knife")
            {
                knifeIcon.SetActive(true);
                hasKnife = true;
            } else if (knifeIcon == null)
            {
                Debug.Log("That piece of shit icon is not found");
            }
            Destroy(gameObject);
        }
    }
}
