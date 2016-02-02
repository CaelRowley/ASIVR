﻿using UnityEngine;
using System.Collections;

public class GunDeckPlayerController : MonoBehaviour {
   public float movementSpeed = 1.0f;
   private bool moveforward = false;

   void Update() {
      if(Cardboard.SDK.Triggered)
         moveforward = !moveforward;

      if(moveforward) {
         transform.position += Camera.main.transform.forward * Time.deltaTime * movementSpeed;
      }
   }
}