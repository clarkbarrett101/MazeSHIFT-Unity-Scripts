using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrackPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    private Vector3 mousePos;
    private Vector3 cPos;
    Player player;
    bool down = false;
    private int mod = 1;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (down)
        {
            Vector3 diff = cPos - mousePos;
            diff.y = diff.x;
            diff.x = 0;
            diff /= 3;
            player.transform.eulerAngles += diff*mod;
            mousePos = cPos;
        }

    }
    public  void ChangeMod()
    {
        mod *= -1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        down = true;
        mousePos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        down = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        cPos = eventData.position;
    }
}