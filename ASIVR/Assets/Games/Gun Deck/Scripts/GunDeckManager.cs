using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GunDeckManager : MonoBehaviour {
   public GameObject timerGameObject;
   public Transform prefabExplosion;
   public int playerHealth;

   private SceneTimer sceneTimer;

   [SerializeField]
   private Text timeHUD = null;
   [SerializeField]
   private Text healthHUD = null;

   private void Start() {
      sceneTimer = (SceneTimer) timerGameObject.GetComponent("SceneTimer");
   }

   // If the player reaches 0 health the game is over, the score is saved and the leaderboard scene is loaded
   private void Update() {
      if(playerHealth <= 0) {
         sceneTimer.SaveScoreHighest();
         SceneManager.LoadScene("GunDeckLeaderboard");
      }

      // Displays the current time on the HUD
      timeHUD.text = sceneTimer.GetCurrentScore().ToString();
   }

   private void OnCollisionEnter(Collision collision) {
      // If the collision object is a HealthBox increment the players health
      if(collision.gameObject.tag == "HealthBox") {
         Destroy(collision.gameObject);
         playerHealth++;

         // Displays players health
         healthHUD.text = playerHealth.ToString();
      }
      // Else removes health
      else {
         Instantiate(prefabExplosion, collision.transform.position, collision.transform.rotation);
         Destroy(collision.gameObject);
         playerHealth--;

         // Displays players health
         healthHUD.text = "Health: " + playerHealth.ToString();
      }
   }
}
