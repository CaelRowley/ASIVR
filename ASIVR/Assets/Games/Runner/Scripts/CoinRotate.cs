using UnityEngine;
using System.Collections;

public class CoinRotate : MonoBehaviour {
   public float rotationSpeed;

   void Update() {
      transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
   }
}
