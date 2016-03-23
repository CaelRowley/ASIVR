using UnityEngine;
using UnityEngine.SceneManagement;

public class GunDeckManager : MonoBehaviour {
   public GameObject timerGameObject;
   SceneTimer sceneTimer;

   public Transform prefabExplosion;
   public int playerHealth;

   void Start() {
      sceneTimer = (SceneTimer) timerGameObject.GetComponent("SceneTimer");
   }

   // If the player reaches 0 health the game is over, the score is saved and the leaderboard scene is loaded
   void Update() {
      if(playerHealth <= 0) {
         sceneTimer.SaveScoreHighest();
         SceneManager.LoadScene("GunDeckLeaderboard");
      }
   }

   void OnCollisionEnter(Collision collision) {
      // If the collision object is a HealthBox increment the players health
      if(collision.gameObject.tag == "HealthBox") {
         Destroy(collision.gameObject);
         playerHealth++;
      }
      // Else removes health
      else {
         Instantiate(prefabExplosion, collision.transform.position, collision.transform.rotation);
         Destroy(collision.gameObject);
         playerHealth--;
      }
   }
}
