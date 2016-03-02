using UnityEngine;

public class PlayerControls : MonoBehaviour {
   public float movementSpeed;
   public float jumpSpeed;
   public float jumpUpdateTime;
   public float jumpFilterStrength;
   public float jumpShakeLimit;

   private bool move = false;
   private float playerPositionX;
   private float playerPositionY;
   private float playerPositionZ;
   private float trackWidth;

   private float jumpMinShakeFilter;
   private Vector3 currentAcceleration = Vector3.zero;
   private Vector3 startAcceleration;
   private Vector3 shake;

   void Start() {
      jumpMinShakeFilter = jumpUpdateTime / jumpFilterStrength;
      playerPositionX = transform.localPosition.x;
      playerPositionY = transform.localPosition.y;
      playerPositionZ = transform.localPosition.z;
      trackWidth = GameObject.FindGameObjectWithTag("Track").transform.localScale.x;
   }

   void Update() {
      // Move is true when the players position is roughly on the ground
      if(transform.position.y >= (playerPositionY - 0.05) && transform.position.y <= (playerPositionY + 0.05) && !move)
         move = true;

      // If Move is true locks movement to left and right on the track
      if(move) {
         transform.position += Camera.main.transform.forward * Time.deltaTime * movementSpeed;

         if(transform.position.x <= playerPositionX - (trackWidth / 2)) {
            transform.position = new Vector3(playerPositionX - (trackWidth / 2), transform.position.y, transform.position.z);
         }
         if(transform.position.x >= playerPositionX + (trackWidth / 2)) {
            transform.position = new Vector3(playerPositionX + (trackWidth / 2), transform.position.y, transform.position.z);
         }
         if(transform.position.y != playerPositionY) {
            transform.position = new Vector3(transform.position.x, playerPositionY, transform.position.z);
         }
         if(transform.position.z != playerPositionZ) {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerPositionZ);
         }
      }

      // Finds the current shake of the accelerometer  
      startAcceleration = Input.acceleration;
      currentAcceleration = Vector3.Lerp(currentAcceleration, startAcceleration, jumpMinShakeFilter);
      shake = startAcceleration - currentAcceleration;

      // The player jumps when the shake goes over the shake limit
      if(shake.sqrMagnitude >= jumpShakeLimit) {
         move = false;
         transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.World);
      }

      // The player jumps when space is pressed
      if(Input.GetKeyDown("space")) {
         move = false;
         transform.Translate(Vector3.up * jumpSpeed * 4 * Time.deltaTime * 3, Space.World);
      }
   }
}
