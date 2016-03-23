using UnityEngine;
using System.Collections;

public class Special_ForceWave : MonoBehaviour {
   public float audioSensitivity;
   public float forceStrength;
   public float threshold;
   public GameObject audioInputGameObject;
   public GameObject projectile;

   private bool isActive = false;
   private AudioInput audioInput;

   void Start() {
      audioInput = (AudioInput) audioInputGameObject.GetComponent("AudioInput");
   }

   // Starts CreateForceWave coroutine if conditions are met
   void Update() {
      float averageVolume = audioInput.GetAverageVolume() * audioSensitivity;

      if(!isActive && averageVolume > threshold) {
         isActive = true;
         StartCoroutine("CreateForceWave", averageVolume);
      }
   }

   // Creates a sphere around the player and destroys all enemies it collides with
   private IEnumerator CreateForceWave(float averageVolume) {

      // Instantiates the projectile for the force wave
      GameObject instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                                                           as GameObject;

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

      // Sets isActive to false when finished
      isActive = false;
   }
}
