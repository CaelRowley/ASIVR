using UnityEngine;
using System.Collections;

public class CollisionExploder : MonoBehaviour {

   void OnCollisionEnter(Collision col) {
      GameObject explosion = (GameObject) Instantiate(Resources.Load("Detonator-Tiny"));
      Instantiate(explosion);
      explosion.transform.position = transform.position;
      Destroy(gameObject);
   }
}
