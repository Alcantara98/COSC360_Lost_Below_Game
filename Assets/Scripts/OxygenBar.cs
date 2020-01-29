using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{

    Image oxygenBar;

    // Start is called before the first frame update
    void Start()
    {
        oxygenBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygenBar.fillAmount = PlayerOxygen.TankAir / PlayerOxygen.TankSize;
    }
}
