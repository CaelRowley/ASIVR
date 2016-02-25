using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCheck : MonoBehaviour {

   void OnCollisionEnter() {
      SceneManager.LoadScene("RunnerLeaderboard");
   }
}
