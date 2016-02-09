using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

   public float speed;
   public string targetName;
   private GameObject targetToFollow;

   // Assigns the target to follow
   void Start() {
      targetToFollow = GameObject.FindGameObjectWithTag(targetName);
   }

   // Moves torwards the target each frame
   void Update() {
      transform.position = Vector3.MoveTowards(transform.position, targetToFollow.transform.position, speed * Time.deltaTime);
   }
}
