using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillZone : MonoBehaviour
{
    public static bool refilling = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            refilling = true;
            StartCoroutine("Refill");
            RespawnMaster.CheckPoint();
            RespawnMaster.playerPos.y = gameObject.transform.position.y - 3;
            RespawnMaster.playerPos.x = gameObject.transform.position.x;
            //Debug.Log(RespawnMaster.playerPos.y);
            //Debug.Log(gameObject.transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            refilling = false;
            StopCoroutine("Refill");
        }
    }

    IEnumerator Refill()
    {
        for (float currentOxygen = PlayerOxygen.TankAir; currentOxygen <= PlayerOxygen.TankSize; currentOxygen += 1f)
        {
            PlayerOxygen.TankAir = currentOxygen;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        PlayerOxygen.TankAir = PlayerOxygen.TankSize;
    }
}
