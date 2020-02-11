using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGrid : MonoBehaviour
{
    public float updateCooldown = 30;
    float updateTimer;
    AstarPath StarGrid;
    // Start is called before the first frame update
    void Start()
    {
        updateTimer = updateCooldown;
        StarGrid = GetComponent<AstarPath>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (updateTimer <= 0 )
        //{
        //    StarGrid.Scan();
        //    updateTimer = updateCooldown;
        //}
        //else
        //{
        //    updateTimer--;
        //}
    }
}
