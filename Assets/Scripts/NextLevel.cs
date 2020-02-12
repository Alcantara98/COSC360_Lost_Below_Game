using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            SceneManager.LoadScene("Level_2");
        }
        //SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }


}
