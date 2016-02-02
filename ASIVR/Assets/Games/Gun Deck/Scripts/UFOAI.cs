using UnityEngine;
using System.Collections;

public class UFOAI : MonoBehaviour {

   public float speed;

   private GameObject targetToFollow;

   // Use this for initialization
   void Start() {
      targetToFollow = GameObject.FindGameObjectWithTag("Player");
   }

   // Update is called once per frame
   void Update() {
      transform.position = Vector3.MoveTowards(transform.position, targetToFollow.transform.position, speed * Time.deltaTime);
   }
}
