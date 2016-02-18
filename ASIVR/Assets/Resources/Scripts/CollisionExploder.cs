using UnityEngine;
using System.Collections;

public class CollisionExploder : MonoBehaviour {
   public Transform prefabExplosion;

   // Destroys both objects and instantiates the explosion prefab on collision
   void OnCollisionEnter(Collision collision) {
      Instantiate(prefabExplosion, transform.position, transform.rotation);
      Destroy(collision.gameObject);
      Destroy(gameObject);
   }
}
