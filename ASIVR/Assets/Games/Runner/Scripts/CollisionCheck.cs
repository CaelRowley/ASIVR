using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionCheck : MonoBehaviour {

   void OnCollisionEnter() {
      SceneManager.LoadScene("RunnerLeaderboard");
   }
}
