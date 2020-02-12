using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMaster : MonoBehaviour
{
    public GameObject respawnPrefab;
    public GameObject[] respawns;
    public GameObject[] originalKnife;
    public GameObject[] originalVine;
    public GameObject[] originalGlow;

    // Start is called before the first frame update
    void Start()
    {
        if (originalKnife == null)
            originalKnife = GameObject.FindGameObjectsWithTag("Knife");

        foreach (GameObject respawn in respawns)
        {
            Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
