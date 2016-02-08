using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {
   public int numOfStars = 100;
   public float starSize = 1;
   public float starDistance = 10;
   public float starClipDistance = 1;

   private Transform starParticleSystem;
   private ParticleSystem.Particle[] stars;

   void Start() {
      starParticleSystem = transform;
      stars = new ParticleSystem.Particle[numOfStars];
      for(int i = 0; i < numOfStars; i++) {
         stars[i].position = Random.insideUnitSphere * starDistance + starParticleSystem.position;
         stars[i].startColor = new Color(1, 1, 1, 1);
         stars[i].startSize = starSize;
      }
   }

   void Update() {
      for(int i = 0; i < numOfStars; i++) {
         if((stars[i].position - starParticleSystem.position).sqrMagnitude > (starDistance * starDistance)) {
            stars[i].position = Random.insideUnitSphere.normalized * starDistance + starParticleSystem.position;
         }

         if((stars[i].position - starParticleSystem.position).sqrMagnitude <= (starClipDistance * starClipDistance)) {
            float percent = (stars[i].position - starParticleSystem.position).sqrMagnitude / (starClipDistance * starClipDistance);
            stars[i].startColor = new Color(1, 1, 1, percent);
            stars[i].startSize = percent * starSize;
         }
      }

      GetComponent<ParticleSystem>().SetParticles(stars, stars.Length);
   }
}
