using UnityEngine;

public class StarField : MonoBehaviour {
   public int numOfStars;
   public float starSize;
   public float starDistance;
   public float starClipDistance;

   private Transform starParticleSystem;
   private ParticleSystem.Particle[] stars;

   void Start() {
      starParticleSystem = transform;
      stars = new ParticleSystem.Particle[numOfStars];
      // Assigns each particle a postion, colour and size
      for(int i = 0; i < numOfStars; i++) {
         stars[i].position = Random.insideUnitSphere * starDistance + starParticleSystem.position;
         // Assigns colour white to each particle
         stars[i].startColor = new Color(1, 1, 1, 1);
         stars[i].startSize = starSize;
      }
   }

   void Update() {
      for(int i = 0; i < numOfStars; i++) {
         // If particle lies outside the sphere it is given a new random position inside the sphere
         if((stars[i].position - starParticleSystem.position).sqrMagnitude > (starDistance * starDistance)) {
            stars[i].position = Random.insideUnitSphere.normalized * starDistance + starParticleSystem.position;
         }

         // Removes particles from view if they are withing the clip distance
         if((stars[i].position - starParticleSystem.position).sqrMagnitude <= (starClipDistance * starClipDistance)) {
            float percent = (stars[i].position - starParticleSystem.position).sqrMagnitude / (starClipDistance * starClipDistance);
            stars[i].startColor = new Color(1, 1, 1, percent);
            stars[i].startSize = percent * starSize;
         }
      }

      GetComponent<ParticleSystem>().SetParticles(stars, stars.Length);
   }
}
