using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreMazeEscape : MonoBehaviour {

   private int[] bestTimes = new int[5];
   private int currentTime = 0;
   private int bestTime = int.MaxValue;
   private string highScoreGameKey = "MazeEscape_HighScore";
   private string highScoreKey;

   void Start() {
      StartCoroutine("Timer");

      for(int i = 0; i < bestTimes.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestTimes[i] = PlayerPrefs.GetInt(highScoreKey, int.MaxValue);
      }
   }

   void Update() {
      if(GameObject.FindGameObjectsWithTag("Key").Length == 0) {
         SaveScore();
         SceneManager.LoadScene("MazeEscapeLeaderboard");
      }
   }

   void SaveScore() {
      for(int i = 0; i < bestTimes.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         bestTime = PlayerPrefs.GetInt(highScoreKey, 0);

         if(currentTime < bestTime) {
            PlayerPrefs.SetInt(highScoreKey, currentTime);
            currentTime = bestTime;
         }

         if(bestTime == 0) {
            PlayerPrefs.SetInt(highScoreKey, currentTime);
            i = bestTimes.Length;
         }
      }
      PlayerPrefs.Save();
   }

   private IEnumerator Timer() {
      while(true) {
         yield return new WaitForSeconds(1);
         currentTime += 1;
      }
   }
}
