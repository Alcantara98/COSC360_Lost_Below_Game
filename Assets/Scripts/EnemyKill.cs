using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    // Start is called before the first frame update
    public float OxygenSize = 75;

    void Start()
    {
        PlayerOxygen.TankAir = OxygenSize;
        PlayerOxygen.TankSize = OxygenSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
