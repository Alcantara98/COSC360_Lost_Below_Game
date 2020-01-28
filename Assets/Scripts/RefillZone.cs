using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerPhysics.TankAir < PlayerPhysics.TankSize)
        {
            StartCoroutine("Refill");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("Refill");
        }
    }

    IEnumerator Refill()
    {
        for (float currentOxygen = PlayerPhysics.TankAir; currentOxygen <= PlayerPhysics.TankSize; currentOxygen += 0.05f)
        {
            PlayerPhysics.TankAir = currentOxygen;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        PlayerPhysics.TankAir = PlayerPhysics.TankSize;
    }
}
