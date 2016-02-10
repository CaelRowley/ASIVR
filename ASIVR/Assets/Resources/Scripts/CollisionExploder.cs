using UnityEngine;
using System.Collections;

public class CollisionExploder : MonoBehaviour {

   public Transform prefabExplosion;

   // Destroys both objects and instantiates the explosion prefab on collision
   void OnCollisionEnter(Collision col) {
      Instantiate(prefabExplosion, transform.position, transform.rotation);
      Destroy(col.gameObject);
      Destroy(gameObject);
   }
}
