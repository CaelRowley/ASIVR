using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GunDeckManager : MonoBehaviour {
   public int playerHealth = 3;

   // If the player reaches 0 health the game is over and the leaderboard scene is loaded
   void Update() {
      if(playerHealth <= 0) {
         SceneManager.LoadScene("GunDeckLeaderboard");
      }
   }

   // Removes health on collision with another object
   void OnCollisionEnter(Collision collision) {
      // If the collision object is a HealthBox increment the players health instead
      if(collision.gameObject.tag == "HealthBox") {
         Destroy(collision.gameObject);
         playerHealth++;
      } else {
         playerHealth--;
      }
   }
}
