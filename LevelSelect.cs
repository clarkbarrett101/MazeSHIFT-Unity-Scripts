using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        int lvl = PlayerPrefs.GetInt("Level", 0);
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i <= lvl;
        }
    }
}