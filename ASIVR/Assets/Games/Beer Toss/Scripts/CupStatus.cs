using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CupStatus : MonoBehaviour {
   public GameObject timerGameObject;

   private SceneTimer sceneTimer;

   [SerializeField]
   private Text timeHUD = null;

   private void Start() {
      sceneTimer = (SceneTimer) timerGameObject.GetComponent("SceneTimer");
   }

   // Ends the game and changes to the leaderboard scene when there are no cups left and saves the score
   private void Update() {
      if(GameObject.FindGameObjectsWithTag("BeerCup").Length == 0) {
         sceneTimer.SaveScoreLowest();
         SceneManager.LoadScene("BeerTossLeaderboard");
      }

      // Displays the current time on the HUD
      timeHUD.text = sceneTimer.GetCurrentScore().ToString();
   }
}
