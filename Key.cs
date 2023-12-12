using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactable
{
   public int keyId;
   public AudioClip pickupSound;
   Player player;
   public Sprite sprite;
   private void OnTriggerEnter(Collider other)
   {
      if(other.tag == "Player")
      {
        player = other.GetComponent<Player>();
        player.interactable = this;
        player.SetInteract(true, sprite);
      }
   }

   private void OnTriggerExit(Collider other)
   {
        if(other.tag == "Player")
        {
            player.interactable = null;
            player.SetInteract(false, null);
        }
   }

   public void Interact()
   {
       player.audioSource.PlayOneShot(pickupSound);
       player.keys[keyId] = true;
       player.interactable = null;
       player.SetInteract(false, null);
               Destroy(gameObject);
   }
}