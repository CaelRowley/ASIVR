using UnityEngine;
using UnityEngine.SceneManagement;

public class CupStatus : MonoBehaviour {
   public GameObject timerGameObject;
   SceneTimer sceneTimer;

   void Start() {
      sceneTimer = (SceneTimer) timerGameObject.GetComponent("SceneTimer");
   }

   // Ends the game and changes to the leaderboard scene when there are no cups left and saves the score
   void Update() {
      if(GameObject.FindGameObjectsWithTag("BeerCup").Length == 0) {
         sceneTimer.SaveScoreLowest();
         SceneManager.LoadScene("BeerTossLeaderboard");
      }
   }
}
