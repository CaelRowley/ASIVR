using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
   public float movementSpeed;
   public float jumpSpeed = 10.0f;
   public float jumpUpdateTime = 1.0f / 60.0f;
   public float jumpFilterStrength = 1.0f;
   public float jumpShakeLimit = 1.0f;

   private bool move = false;
   private float playerPositionX;
   private float playerPositionY;
   private float playerPositionZ;
   private float trackWidth;

   private float jumpMinShakeFilter;
   private Vector3 startAcceleration = Vector3.zero;
   private Vector3 currentAcceleration;
   private Vector3 shake;
   private bool isJumping = false;

   void Start() {
      jumpMinShakeFilter = jumpUpdateTime / jumpFilterStrength;
      playerPositionX = transform.localPosition.x;
      playerPositionY = transform.localPosition.y;
      playerPositionZ = transform.localPosition.z;
      trackWidth = GameObject.FindGameObjectWithTag("Track").transform.localScale.x;
   }

   void Update() {
      // Toggles movement with the magnet switch
      if(Cardboard.SDK.Triggered)
         move = !move;

      // Moves the player when they toggle the magnet and ristricts movement to the x and y axis
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

      // The player jumps when the shake goes over the shake limit
      currentAcceleration = Input.acceleration;
      startAcceleration = Vector3.Lerp(startAcceleration, currentAcceleration, jumpMinShakeFilter);
      shake = currentAcceleration - startAcceleration;

      if(shake.sqrMagnitude >= jumpShakeLimit && !isJumping) {
         move = false;
         //isJumping = true;
         transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.World);
      }

      if(Input.GetKeyDown("space")) {
         move = false;
         transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime * 3, Space.World);
      }

      //if(transform.position.y == playerPositionY)
      //isJumping = false;
   }
}
