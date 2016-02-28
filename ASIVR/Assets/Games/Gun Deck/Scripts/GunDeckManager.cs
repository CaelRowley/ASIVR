using UnityEngine;
using UnityEngine.SceneManagement;

public class GunDeckManager : MonoBehaviour {
   public Transform prefabExplosion;
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
         Instantiate(prefabExplosion, collision.transform.position, collision.transform.rotation);
         Destroy(collision.gameObject);
         playerHealth--;
      }
   }
}
