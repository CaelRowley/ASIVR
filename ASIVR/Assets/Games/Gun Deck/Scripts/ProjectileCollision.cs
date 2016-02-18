using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {
   public Transform prefabExplosion;

   // Destroys both objects and instantiates the explosion prefab on collision
   void OnCollisionEnter(Collision collision) {
      // Does not destory HealthBox objects
      if(collision.gameObject.tag == "HealthBox") {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(gameObject);
      } else {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(collision.gameObject);
         Destroy(gameObject);
      }
   }
}
