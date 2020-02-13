using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject []tut;
    public int tutInt = 0;
    private float defaultMass;
    private float timer = 0f;

    public GameObject player;
    public GameObject boulder;
    public GameObject knife;
    public GameObject glow;
    public GameObject glowStick;
    // Start is called before the first frame update
    void Start()
    {
        defaultMass = boulder.GetComponent<Rigidbody2D>().drag;
        knife.SetActive(false);
        glow.SetActive(false);
        PlayerCollectibles.nglow = 0;
        glowStick.SetActive(false);
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
                    boulder.GetComponent<Rigidbody2D>().drag = 100;
                }
                break;
            case 2:
                if (player.transform.position.y > -3.76)
                {
                    tutInt++;
                }
                break;
            case 3:
                if (player.transform.position.y < -3.76)
                {
                    tutInt++;
                    boulder.GetComponent<Rigidbody2D>().drag = defaultMass;
                }
                break;
            case 4:
                if (player.transform.position.x > 34) tutInt++;
                break;
            case 5:
                if (player.transform.position.x > 36.5)
                {
                        if (timer >= 3f)
                        {
                            tutInt++;
                        knife.SetActive(true);
                        }
                        else
                        {
                            timer += Time.deltaTime;
                            Debug.Log(timer);
                        }
                }
                break;
            case 6:
                if (!knife.activeSelf) tutInt++;
                break;
            case 7:
                if (player.transform.position.x > 39.5) tutInt++;
                break;
            case 8:
                if (player.transform.position.x > 43)
                {
                    tutInt++;
                    glow.SetActive(true);
                    glowStick.SetActive(true);
                    PlayerCollectibles.nglow = 3;
                }
                break;
            case 9:
                if (Input.GetKey(KeyCode.G)) tutInt++;
                break;
            case 10:
                if (timer >= 10f)
                {
                    tutInt++;
                    Debug.Log(tut[tutInt].name);
                }
                else
                {
                    timer += Time.deltaTime;
                    Debug.Log(timer);
                }
                break;
            case 11:
                if (Input.GetKey(KeyCode.Space)) tutInt++;
                break;
            case 12:
                break;
            default:
                tutInt++;
                break;
        }
    }
}
