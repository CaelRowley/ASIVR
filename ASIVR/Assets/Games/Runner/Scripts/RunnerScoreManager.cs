﻿using UnityEngine;
using System.Collections;

public class RunnerScoreManager : MonoBehaviour {
   public string highScoreGameKey;
   public bool bestScoreHigh;

   private int[] bestScores = new int[5];
   public int currentScore;
   private int bestScore;
   private string highScoreKey;

   // Starts the timer and reads current highscores
   void Start() {
      if(bestScoreHigh)
         bestScore = int.MaxValue;
      else
         bestScore = 0;

      for(int i = 0; i < bestScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
      }
   }

   void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag == "PickUp") {
         currentScore++;
         collision.transform.Translate(0, 0, -30);
      }
   }

   // Saves highscore where the higher the score the better
   void SaveScore() {
      for(int i = 0; i < bestScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestScore = PlayerPrefs.GetInt(highScoreKey, 0);

         if(currentScore > bestScore) {
            PlayerPrefs.SetInt(highScoreKey, currentScore);
            currentScore = bestScore;
         }
      }
      PlayerPrefs.Save();
   }

   void OnDestroy() {
      SaveScore();
   }
}
