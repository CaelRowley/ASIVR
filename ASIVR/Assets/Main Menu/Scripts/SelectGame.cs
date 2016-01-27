using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectGame : MonoBehaviour {

	public void SelectScene (string sceneName) {
        SceneManager.LoadScene(sceneName);
	}
}
