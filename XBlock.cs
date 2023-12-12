using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBlock : MonoBehaviour
{
    public bool switchX = false;
    void Update()
    {
        if (SwitchX.switchX == switchX)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}