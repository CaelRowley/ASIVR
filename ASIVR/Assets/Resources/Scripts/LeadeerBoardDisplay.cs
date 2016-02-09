using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeadeerBoardDisplay : MonoBehaviour {

   public string highScoreGameKey;
   public int[] highScores = new int[5];

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

   private string highScoreKey;

   // Reads highscores from the PlayerPrefs and assigns them to the Text fields
   void Start() {
      for(int i = 0; i < highScores.Length; i++) {
         highScoreKey = highScoreGameKey + (i + 1).ToString();
         highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
         print(highScores[i] + " = " + highScoreKey);
      }

      highScore1.text = "First: " + highScores[0].ToString();
      highScore2.text = "Second: " + highScores[1].ToString();
      highScore3.text = "Third: " + highScores[2].ToString();
      highScore4.text = "Fourth: " + highScores[3].ToString();
      highScore5.text = "Fifth: " + highScores[4].ToString();
   }
}
