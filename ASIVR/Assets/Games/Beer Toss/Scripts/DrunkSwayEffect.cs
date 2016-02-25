using UnityEngine;
using System.Collections;

public class DrunkSwayEffect : MonoBehaviour {
   public float drinkSpeedEffect = 1.0f;
   public float drinkForceEffect = 0.1f;
   public float maxDrinkSpeedEffect = 10.0f;
   public float maxDrinkForceEffect = 0.5f;

   private float loopDuration = 30.0f;
   private float shakeSpeed = 0.0f;
   private float shakeForce = 0.0f;
   private int maxBeerCups;
   private int maxWaterCups;

   // Starts a new Shake coroutine and ends all others
   public void StartShake() {
      StopAllCoroutines();
      StartCoroutine("Shake");
   }

   // Assigns the intitial number of cups in the scene to maxCups
   public void Start() {
      maxBeerCups = GameObject.FindGameObjectsWithTag("BeerCup").Length;
      maxWaterCups = GameObject.FindGameObjectsWithTag("WaterCup").Length;
   }

   public void Update() {
      int currentBeerCups = GameObject.FindGameObjectsWithTag("BeerCup").Length;
      int currentWaterCups = GameObject.FindGameObjectsWithTag("WaterCup").Length;

      // When a beer cup is removed start the shake coroutine and increment shake speed and shake force
      if(currentBeerCups < maxBeerCups) {
         shakeSpeed += drinkSpeedEffect;
         shakeForce += drinkForceEffect;
         maxBeerCups--;
         StartShake();
      }

      // When a water cup is removed start the shake coroutine and deducts from the shake speed and shake force
      if(currentWaterCups < maxWaterCups && shakeSpeed > 0.0f && shakeForce > 0.0f) {
         shakeSpeed -= drinkSpeedEffect;
         shakeForce -= drinkForceEffect;
         maxWaterCups--;
         StartShake();
      }

      // Prevents shake speed and shake force from going over the maximum
      if(shakeSpeed > maxDrinkSpeedEffect)
         shakeSpeed = maxDrinkSpeedEffect;
      if(shakeForce > maxDrinkForceEffect)
         shakeSpeed = maxDrinkForceEffect;
   }

   // Shakes the camera giving the drunk effect
   IEnumerator Shake() {
      float time = 0.0f;
      Vector3 originalCamPos = Camera.main.transform.position;
      float randomStart = Random.Range(-1000.0f, 1000.0f);

      while(time < loopDuration) {
         time += Time.deltaTime;

         // Gets less intense over time using intensity and dampness
         float intensity = time / loopDuration;
         float dampness = 1.0f - Mathf.Clamp(2.0f * intensity - 1.0f, 0.0f, 1.0f);
         float sway = randomStart + shakeSpeed * intensity;

         // Uses the SimplexNoise utility to create a random sway based on the Perlin noise
         float x = Util.SimplexNoise.Noise(sway, 0.0f, 0.0f) * 2.0f - 1.0f;
         float y = Util.SimplexNoise.Noise(0.0f, sway, 0.0f) * 2.0f - 1.0f;
         x *= shakeForce * dampness;
         y *= shakeForce * dampness;

         Camera.main.transform.position = new Vector3(x, y + (originalCamPos.y + 0.1f), originalCamPos.z);

         if(time >= loopDuration)
            time = 0.0f;

         yield return null;
      }

      Camera.main.transform.position = originalCamPos;
   }
}
