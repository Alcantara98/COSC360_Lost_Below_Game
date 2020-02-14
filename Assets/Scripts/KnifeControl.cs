using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PlayerCollectibles.hasKnife == false) this.transform.gameObject.SetActive(false);
    }
}
