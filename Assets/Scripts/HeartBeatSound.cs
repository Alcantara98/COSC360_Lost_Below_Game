using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSound : MonoBehaviour
{

    public AudioSource heartBeat_Whole;
    public AudioSource heartBeat_First;
    public AudioSource heartBeat_Last;
    // Start is called before the first frame update
    void Start()
    {
        heartBeat_Whole.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
