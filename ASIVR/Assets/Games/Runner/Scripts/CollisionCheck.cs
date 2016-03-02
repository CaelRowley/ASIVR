using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCheck : MonoBehaviour {

   // Loads the leaderboard on collision 
   void OnCollisionEnter() {
      SceneManager.LoadScene("RunnerLeaderboard");
   }
}
