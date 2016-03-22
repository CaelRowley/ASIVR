using UnityEngine;

public class Special_ForceWave : MonoBehaviour {
   public float audioSensitivity = 100.0f;
   public float forceStrength = 10.0f;
   public float threshold = 5.0f;
   public GameObject audioInputGameObject;

   private AudioInput audioInput;

   void Start() {
      audioInput = (AudioInput) audioInputGameObject.GetComponent("AudioInput");
   }

   // Calls CreateForceWave() if conditions are met
   void Update() {
      float averageVolume = audioInput.GetAverageVolume() * audioSensitivity;

      if(averageVolume > threshold) {
         CreateForceWave(averageVolume);
      }
   }

   // Creates a sphere around the player and destroys all enemies it collides with
   private void CreateForceWave(float averageVolume) {
      float radius = averageVolume * forceStrength;
      Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, radius);

      foreach(Collider collider in colliders) {
         if(collider.tag == "Enemy") {
            Destroy(collider.gameObject);
         }
      }
   }
}
