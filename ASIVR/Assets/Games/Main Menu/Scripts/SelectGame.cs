using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGame : MonoBehaviour {

   // Switches to the new scene
   public void SelectScene(string sceneName) {
      SceneManager.LoadScene(sceneName);
   }
}
