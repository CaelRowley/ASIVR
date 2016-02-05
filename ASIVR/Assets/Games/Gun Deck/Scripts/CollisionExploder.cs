using UnityEngine;
using System.Collections;

public class CollisionExploder : MonoBehaviour {
   public Transform prefab;

   void OnCollisionEnter(Collision col) {
      Instantiate(prefab, transform.position, transform.rotation);
      Destroy(gameObject);
   }
}
