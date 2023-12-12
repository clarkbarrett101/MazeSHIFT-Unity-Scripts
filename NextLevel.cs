using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           FindObjectOfType<Scoreboard>().ShowScore();
        }
    }

    public void level(int i)
    {
        Player.level = i;
        SceneManager.LoadScene(1);
    }

    public static void LoadNextLevel()
    {
        if (Player.level >= 7)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Player.level++;
            if (Player.level > PlayerPrefs.GetInt("Level", 0))
                PlayerPrefs.SetInt("Level", Player.level);
            SceneManager.LoadScene(1);
        }
    }

    public static void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}