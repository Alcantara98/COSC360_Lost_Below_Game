using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMaster : MonoBehaviour
{
    public static GameObject[] originalKnife;
    public static GameObject[] originalVine;
    public static GameObject[] originalGlow;
    public static GameObject[] originalSafe;
    public static GameObject[] checkKnife;
    public static GameObject[] checkVine;
    public static GameObject[] checkGlow;
    public static Vector3 playerPos;
    public static string sceneName;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) RespawnMaster.Respawn();
    }

    public static void CheckPoint()
    {
        checkKnife = GameObject.FindGameObjectsWithTag("Knife");
        checkVine = GameObject.FindGameObjectsWithTag("Vine");
        checkGlow = GameObject.FindGameObjectsWithTag("Glow");

        Debug.Log("checked");
    }

    public static void Respawn()
    {
        SceneManager.LoadScene(sceneName);

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerPos;

        Debug.Log("re");

        originalKnife = GameObject.FindGameObjectsWithTag("Knife");
        originalVine = GameObject.FindGameObjectsWithTag("Vine");
        originalGlow = GameObject.FindGameObjectsWithTag("Glow");

        if (originalKnife != null && checkKnife != null)
        {
            foreach (GameObject knife in originalKnife)
            {
                bool found = false;
                foreach (GameObject reKnife in checkKnife)
                {
                    if (knife.GetInstanceID() == reKnife.GetInstanceID())
                    {
                        found = true;
                    }
                }
                knife.SetActive(found);
            }
        }

        if(originalVine != null && checkVine != null)
        {
            foreach (GameObject vine in originalVine)
            {
                bool found = false;
                foreach (GameObject reVine in checkVine)
                {
                    if (vine.GetInstanceID() == reVine.GetInstanceID())
                    {
                        found = true;
                    }
                }
                vine.SetActive(found);
            }
        }

        if(originalGlow != null && checkGlow != null)
        {
            foreach (GameObject glow in originalGlow)
            {
                bool found = false;
                foreach (GameObject reGlow in checkGlow)
                {
                    if (glow.GetInstanceID() == reGlow.GetInstanceID())
                    {
                        found = true;
                    }
                }
                glow.SetActive(found);
            }
        }

    }
}
