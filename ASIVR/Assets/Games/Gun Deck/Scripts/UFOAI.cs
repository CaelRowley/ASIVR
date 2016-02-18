using UnityEngine;
using System.Collections;

public class UFOAI : MonoBehaviour {
   public float speedMovement;
   public string targetName;
   public float spinDegree;

   public float speedRotate;
   public float targetRotationX;
   public float targetRotationY;
   public float targetRotationZ;

   public Transform prefabExplosion;

   private Quaternion targetSpinRotation;
   private Quaternion targetRotation;
   private GameObject targetToFollow;

   // Assigns the target to follow and target rotation
   void Start() {
      targetRotation = Quaternion.Euler(new Vector3(targetRotationX, targetRotationY, targetRotationZ));
      targetToFollow = GameObject.FindGameObjectWithTag(targetName);
   }

   // Moves torwards the target each frame and roates towards target rotation
   void Update() {
      // Spinsthe UFO
      transform.Rotate(Vector3.forward, spinDegree * Time.deltaTime);
      transform.position = Vector3.MoveTowards(transform.position, targetToFollow.transform.position, speedMovement * Time.deltaTime);

      // 270f is uprightpostiion for the UFO
      if(transform.eulerAngles.x != 270.0f)
         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * speedRotate * Time.deltaTime);
   }

   // Destroys gameObject and instantiates the explosion prefab on collision
   void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag != "Enemy") {
         Instantiate(prefabExplosion, transform.position, transform.rotation);
         Destroy(gameObject);
      }
   }
}
