using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;


public class EnemyLight : MonoBehaviour
{
    public GameObject pointLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<EnemyController>().currentBehaviour == EnemyController.Behaviour.ChasePlayer)
        {
            pointLight.SetActive(true);
        } else
        {
            pointLight.SetActive(false);
        }
    }
}
