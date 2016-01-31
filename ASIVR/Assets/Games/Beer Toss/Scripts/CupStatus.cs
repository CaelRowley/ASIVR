using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CupStatus : MonoBehaviour {

	void Update () {
        if (GameObject.FindGameObjectsWithTag("BeerCup").Length == 0) { SceneManager.LoadScene("MainMenu"); }
    }
}
