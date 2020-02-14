using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMaster : MonoBehaviour
{
    public static GameObject[] originalKnife;
    public static GameObject[] originalVine;
    public static GameObject[] originalGlow;
    public static GameObject[] originalBoulder;
    public static GameObject[] originalEnemy;
    public static GameObject[] originalCurrent;
    public static Vector3[] oriBoulder;
    public static Vector3[] oriEnemy;
    public static Vector3[] oriCurrent;
    public static GameObject[] checkKnife;
    public static GameObject[] checkVine;
    public static GameObject[] checkGlow;
    public static Vector3 playerPos;
    public static string sceneName;
    public static int playerNGlow;
    public static bool playerHasKnife;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        originalBoulder = GameObject.FindGameObjectsWithTag("BoulderSquare");
        originalEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        originalCurrent = GameObject.FindGameObjectsWithTag("Current");
        oriCurrent = new Vector3[originalCurrent.Length];

        if (originalBoulder != null)
        {
            oriBoulder = new Vector3[originalBoulder.Length];
            for (int i = 0; i < originalBoulder.Length; i++)
            {
                oriBoulder[i] = originalBoulder[i].transform.position;
            }

        }
        if (originalEnemy != null)
        {
            oriEnemy = new Vector3[originalEnemy.Length];
            for (int i = 0; i < originalEnemy.Length; i++)
            {
                oriEnemy[i] = originalEnemy[i].transform.position;
            }
        }
        if (originalCurrent != null)
        {
            oriCurrent = new Vector3[originalCurrent.Length];
            for (int i = 0; i < originalCurrent.Length; i++)
            {
                oriCurrent[i] = originalCurrent[i].transform.position;
            }
        }
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

        playerNGlow = PlayerCollectibles.nglow;
        playerHasKnife = PlayerCollectibles.hasKnife;

        //Debug.Log("checked");
    }

    public static void Respawn()
    {
        Debug.Log("hi");
        //SceneManager.LoadScene(sceneName);

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerPos;

        Debug.Log("re");

        originalKnife = GameObject.FindGameObjectsWithTag("Knife");
        originalVine = GameObject.FindGameObjectsWithTag("Vine");
        originalGlow = GameObject.FindGameObjectsWithTag("Glow");

        if (originalBoulder != null )
        {
            for (int i = 0; i < originalBoulder.Length; i++)
            {
                originalBoulder[i].transform.position = oriBoulder[i];
            }
        }

        if (originalCurrent != null)
        {
            for (int i = 0; i < originalCurrent.Length; i++)
            {
                originalCurrent[i].transform.position = oriCurrent[i];
            }
        }

        if (originalEnemy != null)
        {
            for (int i = 0; i < originalEnemy.Length; i++)
            {
                originalEnemy[i].transform.position = oriEnemy[i];
                originalEnemy[i].SetActive(true);
                originalEnemy[i].GetComponent<EnemyController>().currentBehaviour = EnemyController.Behaviour.Idle;
                    //originalEnemy[i].GetComponent<EnemyController>().defaultBehaviour;
            }
        }

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
