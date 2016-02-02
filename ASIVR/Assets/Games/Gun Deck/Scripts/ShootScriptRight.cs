using UnityEngine;
using System.Collections;

public class ShootScriptRight : MonoBehaviour {
   public Rigidbody projectile;
   public float speed = 50;

   void Start() {
      Screen.sleepTimeout = SleepTimeout.NeverSleep;
      StartCoroutine("Shoot");
   }

   private IEnumerator Shoot() {
      yield return new WaitForSeconds(0.5f);
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
