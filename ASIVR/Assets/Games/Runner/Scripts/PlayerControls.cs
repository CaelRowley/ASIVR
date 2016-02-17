using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

   public float speedRotate;
   public float targetRotationX;
   public float targetRotationY;
   public float targetRotationZ;
   public float movementSpeed;

   private Quaternion targetRotation;
   private bool move = false;

   void Start() {
      targetRotation = Quaternion.Euler(new Vector3(targetRotationX, targetRotationY, targetRotationZ));
   }
   
   void Update() {
      // Keeps the player upright
      if(transform.eulerAngles.x > 271f || transform.eulerAngles.x < 269f)
         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * speedRotate * Time.deltaTime);

      if(Cardboard.SDK.Triggered)
         move = !move;

      // Moves the player when they toggle the magnet and ristricts movement to the x and y axis
      if(move) {
         transform.position += Camera.main.transform.forward * Time.deltaTime * movementSpeed;

         if(transform.position.x <= -5) {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
         }
         if(transform.position.x >= 5) {
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
         }
         if(transform.position.z != 15) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
         }
      }
   }
}
