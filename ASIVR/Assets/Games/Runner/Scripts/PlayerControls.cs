using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

   public float speedRotate;
   public float targetRotationX;
   public float targetRotationY;
   public float targetRotationZ;
   private Quaternion targetRotation;

   // Use this for initialization
   void Start() {
      targetRotation = Quaternion.Euler(new Vector3(targetRotationX, targetRotationY, targetRotationZ));
   }

   // Update is called once per frame
   void Update() {
      if(transform.eulerAngles.x > 271f || transform.eulerAngles.x < 269f)
         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * speedRotate * Time.deltaTime);
   }
}
