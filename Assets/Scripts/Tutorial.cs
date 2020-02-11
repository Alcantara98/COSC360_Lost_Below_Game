using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject []tut;
    private int tutInt = 0;
    private float defaultMass;
    private float timer = 0f;

    public GameObject player;
    public GameObject boulder;
    public GameObject knife;
    // Start is called before the first frame update
    void Start()
    {
        defaultMass = boulder.GetComponent<Rigidbody2D>().mass;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tut.Length; i++)
        {
            if (i == tutInt)
            {
                tut[tutInt].SetActive(true);
            } else
            {
                tut[i].SetActive(false);
            }
        }

        switch (tutInt)
        {
            case 0:
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
                {
                    tutInt++;
                }
                break;
            case 1:
                if (player.transform.position.x > 23)
                {
                    tutInt++;
                    boulder.GetComponent<Rigidbody2D>().mass = 100;
                }
                break;
            case 2:
                if (player.transform.position.y > -3.76)
                {
                    tutInt++;
                    boulder.GetComponent<Rigidbody2D>().mass = defaultMass;
                }
                break;
            case 3:
                if (player.transform.position.x > 34) tutInt++;
                break;
            case 4:
                if (player.transform.position.x > 40.5)
                {
                        if (timer >= 5f)
                        {
                            tutInt++;
                        }
                        else
                        {
                            timer += Time.deltaTime;
                            Debug.Log(timer);
                        }
                }
                break;
            case 5:
                if (knife.activeSelf) tutInt++;
                break;
            case 6:
                if (player.transform.position.x > 39.5) tutInt++;
                break;
            case 7:
                if (player.transform.position.x > 43) tutInt++;
                break;
            case 8:
                if (Input.GetKey(KeyCode.G)) tutInt++;
                break;
            case 9:
                if (timer >= 10f) tutInt++;
                else
                {
                    timer += Time.deltaTime;
                    Debug.Log(timer);
                }
                break;
            default:
                tutInt++;
                break;
        }
    }
}
