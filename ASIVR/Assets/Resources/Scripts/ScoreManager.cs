using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
   public string highScoreGameKey;
   public bool bestScoreHigh;

   private int[] bestScores = new int[5];
   private int currentScore;
   private int bestScore;
   private string highScoreKey;

   // Starts the timer and reads current highscores
   void Start() {
      StartCoroutine("Timer");

      if(bestScoreHigh)
         bestScore = int.MaxValue;
      else
         bestScore = 0;

      for(int i = 0; i < bestScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
      }
   }

   // Saves highscore where the higher the score the better
   void SaveScoreHighest() {
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

   // Saves highscore where the lower the score the better
   void SaveScoreLowest() {
      for(int i = 0; i < bestScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestScore = PlayerPrefs.GetInt(highScoreKey, 0);

         if(currentScore < bestScore) {
            PlayerPrefs.SetInt(highScoreKey, currentScore);
            currentScore = bestScore;
         }

         if(bestScore == 0) {
            PlayerPrefs.SetInt(highScoreKey, currentScore);
            i = bestScores.Length;
         }
      }
      PlayerPrefs.Save();
   }

   private IEnumerator Timer() {
      while(true) {
         yield return new WaitForSeconds(1);
         currentScore += 1;
      }
   }

   // Saves highscore on death
   void OnDestroy() {
      if(bestScoreHigh)
         SaveScoreHighest();
      else
         SaveScoreLowest();
   }
}