using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchX : MonoBehaviour, Interactable
{
    public static bool switchX = false;
   Animator anim;
   public AudioClip switchSound;
   public Sprite[] sprite;
   Player player;
   private void Start()
   {
       switchX = false;
        anim = GetComponent<Animator>();
   }
   private void OnTriggerEnter(Collider other)
   {
       if(other.tag == "Player")
       {
           player = other.GetComponent<Player>();
           player.interactable = this;
           player.SetInteract(true, switchX? sprite[1] : sprite[0]);
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
       switchX = !switchX;
       player.audioSource.PlayOneShot(switchSound);
         anim.SetBool("X", switchX);
         player.SetInteract(true, switchX? sprite[1] : sprite[0]);
   }
}