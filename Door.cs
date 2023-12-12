using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    public Animator anim;
    public Player player;
    public int keyId;
    public AudioClip openSound;
    bool open = false;
    public Sprite sprite;

    private void Start()
    {
        player = FindObjectOfType<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && player.keys[keyId])
        {

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
        player.interactable = null;
        player.audioSource.PlayOneShot(openSound);
        player.SetInteract(false, null);
        anim.SetBool("Open", true);
        Destroy(gameObject,.5f);
    }
}