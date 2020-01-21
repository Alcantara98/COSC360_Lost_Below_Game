using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turning();
    }

    void turning()
    {
        //Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = targetRotation;
        //Vector2 direc = new Vector2(- mousePos.y + transform.position.x, mousePos.x - transform.position.y);
        //transform.right = direc;
    }
}
