using UnityEngine;

public class Player_Throw : MonoBehaviour {
   public Rigidbody projectile;
   public float speed = 5;

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
