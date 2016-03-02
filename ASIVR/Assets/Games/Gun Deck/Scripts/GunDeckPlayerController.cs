using UnityEngine;

public class GunDeckPlayerController : MonoBehaviour {
   public float movementSpeed;

   private bool moveforward = false;

   // Toggles move forward with the magnet switch
   void Update() {
      if(Cardboard.SDK.Triggered)
         moveforward = !moveforward;

      if(moveforward) {
         transform.position += Camera.main.transform.forward * Time.deltaTime * movementSpeed;
      }
   }
}
