using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
   public Rigidbody projectile;
   public float speed;
   public float delay;

   private void Start() {
      StartCoroutine("Shoot");
   }

   // Waits for the delay then shoots projectile every second
   private IEnumerator Shoot() {
      yield return new WaitForSeconds(delay);
      while(true) {
         yield return new WaitForSeconds(1);
         Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                        transform.position,
                                                        transform.rotation)
                                                        as Rigidbody;
         instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
      }
   }
}
