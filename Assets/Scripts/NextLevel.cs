using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string LevelToLoad = "Level_2";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerCollectibles.nglow = 0;
            PlayerCollectibles.hasKnife = false;
            PlayerOxygen.TankAir = PlayerOxygen.TankSize;
            SceneManager.LoadScene(LevelToLoad);
        }
        //SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }


}
