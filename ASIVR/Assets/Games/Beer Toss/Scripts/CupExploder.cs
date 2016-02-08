using UnityEngine;
using System.Collections;

public class CupExploder : MonoBehaviour {

   public float collisionTimeRequired = 1.0f;
   public Transform prefabExplosion;

   private float collisionCurrentTime = 0.0f;
   private bool continueTimer;

   // Flags contact timer true when collision occurs
   void OnCollisionEnter(Collision col) {
      continueTimer = true;
   }

   // Flags contact timer false when collision is over
   void OnCollisionLeave(Collision col) {
      continueTimer = false;
   }

   // Destroys both objects and instantiates the explosion prefab if requirements are met
   void OnCollisionStay(Collision col) {
      collisionCurrentTime += Time.deltaTime;

      if(collisionCurrentTime > collisionTimeRequired && continueTimer) {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(col.gameObject);
         Destroy(gameObject);
      }
   }
}
