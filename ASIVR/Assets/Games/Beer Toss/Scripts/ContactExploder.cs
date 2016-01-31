using UnityEngine;
using System.Collections;

public class ContactExploder : MonoBehaviour {

   void OnCollisionEnter(Collision col) {
      Destroy(col.gameObject);
      Destroy(col.transform.parent.gameObject);
   }
}
