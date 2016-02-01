using UnityEngine;
using System.Collections;

public class MazePortal : MonoBehaviour {

   void OnCollisionEnter(Collision col) {
      Destroy(gameObject);
   }
}
