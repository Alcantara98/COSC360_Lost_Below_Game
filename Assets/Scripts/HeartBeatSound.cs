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
        Application.targetFrameRate = 1;
        audioSource.GetComponents<AudioSource>();
        audioSource.PlayOneShot(heartBeat_Whole, 1);
        timePassed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(PlayerOxygen.TankAir/PlayerOxygen.TankSize < 0.15f && timePassed > heartAttackBeat)
        {
            Debug.Log("first");
            audioSource.PlayOneShot(heartBeat_First, 1);
            timePassed = 0;
        }
        else if (PlayerOxygen.TankAir / PlayerOxygen.TankSize < 0.35f && timePassed > fastHeartBeat)
        {
            audioSource.PlayOneShot(heartBeat_First, 1);
            timePassed = 0;
            Debug.Log("Second");
        }
        else if (PlayerOxygen.TankAir / PlayerOxygen.TankSize < 0.6f && timePassed > mediumHeartBeat)
        {
            audioSource.PlayOneShot(heartBeat_Whole, 1);
            timePassed = 0;
            Debug.Log("Third");
        }
        else if (timePassed > slowHeartBeat)
        {
            audioSource.PlayOneShot(heartBeat_Whole, 1);
            timePassed = 0;
            Debug.Log("Fourth");
        }
    }
}
