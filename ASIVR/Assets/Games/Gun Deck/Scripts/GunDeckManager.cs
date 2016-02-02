using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GunDeckManager : MonoBehaviour {

   public int playerHealth = 3;

   void Start() {

   }

   // Update is called once per frame
   void Update() {
      if(playerHealth <= 0) {
         SceneManager.LoadScene("GunDeckLeaderboard");
      }
   }

   void OnCollisionEnter(Collision col) {
      playerHealth--;
   }
}
