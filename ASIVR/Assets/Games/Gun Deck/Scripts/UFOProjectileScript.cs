using UnityEngine;
using System.Collections;

public class UFOProjectileScript : MonoBehaviour {
   public Transform prefabExplosion;

   // Destroys both objects and instantiates the explosion prefab on collision
   void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag != "Enemy") {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(gameObject);
      }
   }
}
