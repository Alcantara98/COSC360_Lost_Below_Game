using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    public static float TankSize = 30.0f;
    public static float TankAir = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RefillZone.refilling == false)
        {
            UseOxygen();
        }
        
    }

    void UseOxygen()
    {
        TankAir -= Time.smoothDeltaTime;
        Debug.Log("O2 Left: " + TankAir);

        if (TankAir <= 0)
        {
            Debug.Log("YOUR OUT OF OXYGEN RETARD");
            TankAir = 0.0f;
        }
    }
}
