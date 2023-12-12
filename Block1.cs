using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1 : MonoBehaviour
{
    private Material mat;
    public float speed;
    private float offset;
    float brightness = 0.5f;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetColor("_EmissionColor", mat.color);
    }

    private void Update()
    {
        brightness = Mathf.PingPong(Time.time, speed);
        mat.SetColor("_EmissionColor", mat.color * brightness);
    }
}