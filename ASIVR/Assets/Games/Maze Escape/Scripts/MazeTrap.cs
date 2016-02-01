using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MazeTrap : MonoBehaviour {

   void OnCollisionEnter(Collision col) {
      SceneManager.LoadScene("MazeEscapeDeathScene");
   }
}
