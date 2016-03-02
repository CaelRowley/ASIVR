using UnityEngine;

public class PlayerThrow : MonoBehaviour {
   public Rigidbody projectile;
   public float speed;

   // Spawns projectile when the magnet switch is used
   void Update() {
      if(Cardboard.SDK.Triggered) {
         Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                        transform.position,
                                                        transform.rotation)
                                                        as Rigidbody;
         instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
      }
   }
}
