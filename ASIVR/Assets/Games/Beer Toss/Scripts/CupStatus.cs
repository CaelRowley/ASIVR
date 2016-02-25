using UnityEngine;
using UnityEngine.SceneManagement;

public class CupStatus : MonoBehaviour {
   // Ends the game and changes to the leaderboard scene when there are no cups left
   void Update() {
      if(GameObject.FindGameObjectsWithTag("BeerCup").Length == 0) { SceneManager.LoadScene("BeerTossLeaderboard"); }
   }
}
