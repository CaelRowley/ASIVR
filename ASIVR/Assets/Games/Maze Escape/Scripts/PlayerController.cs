using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
   public float movementSpeed = 1.0f;

   private bool moveforward = false;
   private Vector3 forward;

   void Update() {
      if(Cardboard.SDK.Triggered)
         moveforward = !moveforward;

      if(moveforward) {
         forward = Camera.main.transform.forward;
         forward.y = 0.0f;
         transform.position += forward * Time.deltaTime * movementSpeed;
      }

   }
}
