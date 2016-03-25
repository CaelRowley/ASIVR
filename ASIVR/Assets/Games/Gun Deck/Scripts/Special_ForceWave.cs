using UnityEngine;
using System.Collections;

public class Special_ForceWave : MonoBehaviour {
   public float audioSensitivity;
   public float forceStrength;
   public float threshold;
   public float cooldown;

   public GameObject audioInputGameObject;
   public GameObject gunDeckGameObject;
   public GameObject projectile;

   private bool isActive = false;
   private AudioInput audioInput;
   private GunDeckManager gunDeckManager;

   private void Start() {
      audioInput = (AudioInput) audioInputGameObject.GetComponent("AudioInput");
      gunDeckManager = (GunDeckManager) gunDeckGameObject.GetComponent("GunDeckManager");
   }

   // Starts CreateForceWave coroutine if conditions are met
   private void Update() {
      float averageVolume = audioInput.GetAverageVolume() * audioSensitivity;
      int ammoCount = gunDeckManager.getAmmoCount();

      if(!isActive && averageVolume > threshold && ammoCount > 0) {
         isActive = true;
         gunDeckManager.setAmmoCount(--ammoCount);
         StartCoroutine("CreateForceWave", averageVolume);
      }

      // For testing purposes only when a microphone is unavailable
      // Starts CreateForceWave coroutine when space is pressed
      if(!isActive && Input.GetKeyDown("space") && ammoCount > 0) {
         isActive = true;
         gunDeckManager.setAmmoCount(--ammoCount);
         StartCoroutine("CreateForceWave", 100);
      }
   }

   // Creates a sphere around the player and destroys all enemies it collides with
   private IEnumerator CreateForceWave(float averageVolume) {

      // Instantiates the projectile for the force wave
      GameObject instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation *= Quaternion.Euler(90, 0, 0))
                                                           as GameObject;

      //instantiatedProjectile.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

      // Waits for the projectile animation
      yield return new WaitForSeconds(0.5f);

      // Creates the overlap sphere with a radius based on the volume of if the audio input
      float radius = averageVolume * forceStrength;
      Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, radius);

      // Destroys all objects with tag "Enemy" that collide with the overlap sphere
      foreach(Collider collider in colliders) {
         if(collider.tag == "Enemy") {
            Destroy(collider.gameObject);
         }
      }

      // Waits for the cooldown
      yield return new WaitForSeconds(cooldown);

      // Sets isActive to false when finished
      isActive = false;
   }
}
