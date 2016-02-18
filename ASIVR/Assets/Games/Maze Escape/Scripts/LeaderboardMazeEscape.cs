using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderboardMazeEscape : MonoBehaviour {

   [SerializeField]
   private Text highScore1 = null;
   [SerializeField]
   private Text highScore2 = null;
   [SerializeField]
   private Text highScore3 = null;
   [SerializeField]
   private Text highScore4 = null;
   [SerializeField]
   private Text highScore5 = null;

   int[] highScores = new int[5];
   string highScoreGameKey = "MazeEscape_HighScore";
   string highScoreKey;

   void Start() {

      for(int i = 0; i < highScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
      }

      highScore1.text = "1: " + highScores[0].ToString();
      highScore2.text = "2: " + highScores[1].ToString();
      highScore3.text = "3: " + highScores[2].ToString();
      highScore4.text = "4: " + highScores[3].ToString();
      highScore5.text = "5: " + highScores[4].ToString();
   }
}
