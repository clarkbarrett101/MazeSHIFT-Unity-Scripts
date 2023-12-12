using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
   public Text scoreText;
   public Text highScoreText;
   private float time;
   public GameObject scoreCard;
   public GameObject canvas;
   private void Start()
   {
      time = Time.time;
   }

   public void ShowScore()
   {
      scoreCard.SetActive(true);
      canvas.SetActive(false);
      scoreText.text = (Time.time - time).ToString("F2");
      float highScore = PlayerPrefs.GetFloat("HighScore"+Player.level, 9999);
      if(Time.time - time < highScore )
      {
         highScore = Time.time - time;
         PlayerPrefs.SetFloat("HighScore"+Player.level, highScore);
      }
      highScoreText.text = highScore.ToString("F2");

   }
}