using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollectibles : MonoBehaviour
{
    public GameObject knifeIcon;
    public static bool hasKnife = false;

    public GameObject glowstick;
    public GameObject glowInstance;

    //number of glowsticks
    public static int nglow = 3;

    public TextMeshProUGUI glowNum;

    private void Start()
    {
        glowNum = GameObject.Find("GlowNum").GetComponent<TextMeshProUGUI>();
        glowNum.text = " X " + nglow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && nglow > 0)
        {
            DropGlowstick();
        }

        glowNum.text = " X " + nglow;
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
            }
            else if (knifeIcon == null)
            {
                Debug.Log("That piece of shit icon is not found");
            }
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "Glow")
        {
            nglow++;
            collider.gameObject.SetActive(false);
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
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public void DropGlowstick()
    {
        glowInstance = Instantiate(glowstick, transform.position + new Vector3(0, -0.2f, 0), Quaternion.identity);
        nglow--;
        Destroy(glowInstance, 30);
    }
}
