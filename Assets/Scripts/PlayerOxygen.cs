using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOxygen : MonoBehaviour
{
    public static float TankSize = 80.0f;
    public static float TankAir = 80.0f;
    public float deathTimer = 2.0f;

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

        if (TankAir <= 0) {
            StartCoroutine(Deth());
        }

    }

    void UseOxygen()
    {
        TankAir -= Time.smoothDeltaTime;
        //Debug.Log("O2 Left: " + TankAir);

        if (TankAir <= 0)
        {
            //Debug.Log("YOUR OUT OF OXYGEN RETARD");
            TankAir = 0.0f;
        }
    }

    public bool DecreaseOxygen(float amt)
    {
        if (TankAir > amt + 2)
        {
            TankAir -= amt;
            return true;
        }
        return false;
    }

    public IEnumerator Deth()
    {
        yield return new WaitForSeconds(2);

        if (TankAir > 0) 
            yield break;
        

        SceneManager.LoadScene("GameOver");
    }
}
