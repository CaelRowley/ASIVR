using UnityEngine;

public class CupExploder : MonoBehaviour {
   public float collisionTimeRequired;
   public Transform prefabExplosion;

   private float collisionCurrentTime = 0.0f;
   private bool continueTimer = false;

   // Flags contact timer true when collision occurs
   private void OnCollisionEnter(Collision col) {
      continueTimer = true;
   }

   // Flags contact timer false when collision is over
   private void OnCollisionLeave(Collision col) {
      continueTimer = false;
   }

   // Destroys both objects and instantiates the explosion prefab if requirements are met
   private void OnCollisionStay(Collision col) {
      collisionCurrentTime += Time.deltaTime;

      if(collisionCurrentTime > collisionTimeRequired && continueTimer) {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(col.gameObject);
         Destroy(gameObject);
      }
   }
}
