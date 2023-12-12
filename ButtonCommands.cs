using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   Player player;
   public Command c;
   public Image sr;
   InterstitialAd interstitialAd;

   public void OnPointerDown(PointerEventData eventData)
   {
      switch (c)
      {
         case Command.Up:
            player.move = Vector3.forward;
            sr.color = Color.green;
            break;
         case Command.Down:
            player.move = Vector3.back;
            sr.color = Color.green;
            break;
         case Command.Left:
            player.move = Vector3.left;
            sr.color = Color.green;
            break;
         case Command.Right:
            player.move = Vector3.right;
            sr.color = Color.green;
            break;
         case Command.shift:
            player.OnShift();
            break;
         case Command.Interact:
            player.interactable.Interact();
            break;
         case Command.NextLevel:
            interstitialAd.ShowAd(true);
            break;
         case Command.Restart:
            interstitialAd.ShowAd(false);
            break;
      }
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      sr.color = Color.white;
      player.move = Vector2.zero;
   }


   public enum Command
   {
      Up,
      Down,
      Left,
      Right,
      shift,
      Interact,
      NextLevel,
      Restart
   }

   private void Start()
   {
      if(sr == null)
      sr = GetComponent<Image>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      interstitialAd = FindObjectOfType<InterstitialAd>();
   }

}