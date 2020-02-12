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
            originalKnife = GameObject.FindGameObjectsWithTag("Knife");

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject respawn in originalKnife)
        {
            Debug.Log(respawn.transform.position.x);
        }
    }
}
