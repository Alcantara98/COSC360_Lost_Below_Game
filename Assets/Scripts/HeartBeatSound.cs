using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSound : MonoBehaviour
{

    public AudioClip heartBeat_Whole;
    public AudioClip heartBeat_First;
    public AudioClip heartBeat_Last;
    public AudioSource audioSource;

    private float timePassed;
    public float slowHeartBeat;
    public float mediumHeartBeat;
    public float fastHeartBeat;
    public float heartAttackBeat;

    // Start is called before the first frame update
    void Start()
    { 
        audioSource.GetComponents<AudioSource>();
        //audioSource.PlayOneShot(heartBeat_Whole, 1);
        timePassed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(PlayerOxygen.TankAir/PlayerOxygen.TankSize < 0.1f && timePassed > heartAttackBeat)
        {
            audioSource.PlayOneShot(heartBeat_First, 1);
            timePassed = 0;
        }
        else if (PlayerOxygen.TankAir / PlayerOxygen.TankSize < 0.25f && timePassed > fastHeartBeat)
        {
            audioSource.PlayOneShot(heartBeat_First, 1);
            timePassed = 0;
        }
        
        else if (PlayerOxygen.TankAir / PlayerOxygen.TankSize < 0.4f && timePassed > mediumHeartBeat)
        {
            audioSource.PlayOneShot(heartBeat_Whole, 1);
            timePassed = 0;
        }
        /*
        else if (timePassed > slowHeartBeat)
        {
            audioSource.PlayOneShot(heartBeat_Whole, 1);
            timePassed = 0;
        }
        */
    }
}
