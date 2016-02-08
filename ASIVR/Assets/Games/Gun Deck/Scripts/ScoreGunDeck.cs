using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreGunDeck : MonoBehaviour {

   private int[] bestScores = new int[5];
   private int currentScore = 0;
   private int bestScore = 0;
   private string highScoreGameKey = "GunDeck_HighScore";
   private string highScoreKey;

   void Start() {
      StartCoroutine("Timer");

      for(int i = 0; i < bestScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
      }
   }

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

   private IEnumerator Timer() {
      while(true) {
         yield return new WaitForSeconds(1);
         currentScore += 1;
      }
   }

   void OnDestroy() {
      SaveScore();
   }
}
