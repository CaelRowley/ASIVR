﻿using UnityEngine;

public class UFOAI : MonoBehaviour {
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

   public Transform prefabExplosion;

   private Transform targetToFollow;
   private float distanceToTarget;
   private bool isTooClose = false;
   private bool inRange = false;

   private void Start() {
      currentSpeed = defaultSpeed;
      targetToFollow = GameObject.FindGameObjectWithTag(targetName).transform;

      InvokeRepeating("Shoot", 2, fireRate);
   }

   private void Update() {
      distanceToTarget = Vector3.Distance(targetToFollow.position, transform.position);

      // Rotates to look at the target
      var rotate = Quaternion.LookRotation(targetToFollow.position - transform.position);
      transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * rotationSpeed);

      // Moves to or away from target
      if(!isTooClose)
         transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
      else
         transform.Translate(Vector3.back * defaultSpeed * Time.deltaTime);

      // Toggles in range
      if(distanceToTarget > attackRange)
         inRange = false;
      else
         inRange = true;

      // Toggles is too close
      if(distanceToTarget <= dangerZone)
         isTooClose = true;
      else if(distanceToTarget > attackRange - 0.5)
         isTooClose = false;

      // Increase acceleration if away from target
      if(distanceToTarget > attackRange) {
         currentSpeed += acceleration;
         currentSpeed = Mathf.Clamp(currentSpeed, minimumSpeed, maximumSpeed);
      }
   }

   // Spawns projectile
   private void Shoot() {
      if(inRange) {
         Rigidbody instantiatedProjectile = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
         Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), GetComponent<Collider>());
         instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
      }
   }

   // Destroys colliding game objects if conditions are met
   private void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "HealthBox" && collision.gameObject.tag != "Player") {
         Destroy(collision.gameObject);
         Destroy(gameObject);
      }
   }

   // Instantiates explosion prefab when destroyed
   private void OnDestroy() {
      Instantiate(prefabExplosion, transform.position, transform.rotation);
   }
}
