using UnityEngine;

public class ProjectileCollision : MonoBehaviour {
   public Transform prefabExplosion;

   void OnCollisionEnter(Collision collision) {
      // Destroys both objects and instantiates the explosion prefab on collision
      if(collision.gameObject.tag != "HealthBox" && collision.gameObject.tag != "Player") {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(collision.gameObject);
         Destroy(gameObject);
      } else { // Does not destroy HealthBox objects or the Player
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(gameObject);
      }
   }
}
