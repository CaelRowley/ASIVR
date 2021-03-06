﻿using UnityEngine;
using UnityEngine.UI;

public class RunnerScoreManager : MonoBehaviour {
   public string highScoreGameKey;
   public bool bestScoreHigh;
   public float endOfTrackZValue;
   public int currentScore;
   public AudioClip audioClipPickUp;

   private int[] bestScores = new int[5];
   private int bestScore;
   private string highScoreKey;
   private AudioSource audioSource;

   [SerializeField]
   private Text ScoreHUD = null;

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

      // Creates audio source for player
      GameObject child = new GameObject("Player");
      child.transform.parent = gameObject.transform;
      audioSource = child.AddComponent<AudioSource>();
   }

   // Adds score on collision with a PickUp and moves the pickup out of view to die
   void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag == "PickUp") {
         audioSource.PlayOneShot(audioClipPickUp);
         currentScore++;

         // Displays current score on the HUD
         ScoreHUD.text = currentScore.ToString();

         // Moves object to the end of the track so its own destructor will activate
         collision.transform.Translate(0, 0, endOfTrackZValue, Space.World);
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
