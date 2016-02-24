using UnityEngine;
using System.Collections;

public class CirclePlayer : MonoBehaviour {

   public float defaultSpeed;
   public float currentSpeed;
   public float acceleration;
   public float minimumSpeed;
   public float maximumSpeed;
   public float rotationSpeed;

   public float dangerZone;
   public string targetName;
   public float attackRange;

   public Rigidbody projectile;
   public float projectileSpeed;
   public float fireRate;

   private Transform targetToFollow;
   private float distanceToTarget;
   private Transform UFO;
   private bool isTooClose = false;
   private bool inRange = false;

   void Start() {
      currentSpeed = defaultSpeed;
      UFO = transform;
      targetToFollow = GameObject.FindGameObjectWithTag(targetName).transform;

      InvokeRepeating("Shoot", 2, fireRate);
   }

   void Update() {
      distanceToTarget = Vector3.Distance(targetToFollow.position, transform.position);
      var rotate = Quaternion.LookRotation(targetToFollow.position - transform.position);
      transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * rotationSpeed);

      if(distanceToTarget > attackRange) {
         currentSpeed += acceleration;
         currentSpeed = Mathf.Clamp(currentSpeed, minimumSpeed, maximumSpeed);
      } else if(distanceToTarget <= dangerZone) {
         float targetSpeed = defaultSpeed;

         if(targetSpeed < currentSpeed) {
            currentSpeed -= acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, targetSpeed, maximumSpeed);
         } else if(targetSpeed > currentSpeed) {
            currentSpeed += acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, minimumSpeed, targetSpeed);
         }
         isTooClose = true;
      }
      if(!isTooClose)
         transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
      else
         transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);

      if(distanceToTarget > attackRange)
         inRange = false;
      else
         inRange = true;

      if(distanceToTarget > dangerZone)
         isTooClose = false;
   }

   void Shoot() {
      if(inRange) {
         Rigidbody instantiatedProjectile = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
         Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), GetComponent<Collider>());
         instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
      }
   }
}
