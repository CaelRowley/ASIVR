using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GunDeckManager : MonoBehaviour {
   public GameObject timerGameObject;
   public Transform prefabExplosion;
   public int playerHealth;
   public int ammoCount;
   public AudioClip audioClipPickUp;

   private SceneTimer sceneTimer;
   private AudioSource audioSource;

   [SerializeField]
   private Text timeHUD = null;
   [SerializeField]
   private Text healthHUD = null;
   [SerializeField]
   private Text ammoHUD = null;

   private void Start() {
      // Creates audio source for player
      GameObject child = new GameObject("Player");
      child.transform.parent = gameObject.transform;
      audioSource = child.AddComponent<AudioSource>();

      sceneTimer = (SceneTimer) timerGameObject.GetComponent("SceneTimer");
   }

   // If the player reaches 0 health the game is over, the score is saved and the leaderboard scene is loaded
   private void Update() {
      if(playerHealth <= 0) {
         sceneTimer.SaveScoreHighest();
         SceneManager.LoadScene("GunDeckLeaderboard");
      }

      UpdateHUD();
   }

   private void OnCollisionEnter(Collision collision) {
      // If the collision object is a PickUp increment the players health and ammo
      if(collision.gameObject.tag == "PickUp") {
         audioSource.PlayOneShot(audioClipPickUp);
         Destroy(collision.gameObject);
         playerHealth++;
         ammoCount++;
      }
      // Else removes health
      else {
         Instantiate(prefabExplosion, collision.transform.position, collision.transform.rotation);
         Destroy(collision.gameObject);
         playerHealth--;
      }
   }

   // Updates the ingame HUD
   private void UpdateHUD() {
      timeHUD.text = sceneTimer.GetCurrentScore().ToString();
      healthHUD.text = "Health: " + playerHealth.ToString();
      ammoHUD.text = "Ammo: " + ammoCount.ToString();
   }

   public int getAmmoCount() {
      return ammoCount;
   }

   public void setAmmoCount(int newAmmoCount) {
      this.ammoCount = newAmmoCount;
   }
}
