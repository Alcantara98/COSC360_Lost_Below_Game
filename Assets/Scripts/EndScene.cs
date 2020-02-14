using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
	public GameObject[] end;
	public int endInt = 0;
	private float defaultMass;
	private float timer = 0f;

	public GameObject player;
	public GameObject boulder;
	public GameObject knife;
	public GameObject glow;
	public GameObject glowStick;
	// Start is called before the first frame update

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < end.Length; i++)
		{
			if (i == endInt)
			{
				end[endInt].SetActive(true);
			}
			else
			{
				end[i].SetActive(false);
			}
		}


	}
}



