using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    // Start is called before the first frame update

    List<Transform> bodyParts = new List<Transform>();

    void Start()
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform t in transforms)
        {
            if (t.GetComponent<Rigidbody2D>() != null)
            {
                bodyParts.Add(t);
                t.GetComponent<Collider>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Explode();
        }  
    }

    public void Explode()
    {
        foreach (Transform t in bodyParts)
        {
            float random = Random.Range(0f, 260f);
            Vector2 direction = new Vector2(Mathf.Cos(random), Mathf.Sin(random));
            Rigidbody2D rb = t.GetComponent<Rigidbody2D>();
            //t.GetComponent<SpriteSkin>().enabled = false;
            rb.AddForce(direction * 100);
        }
    }
}
