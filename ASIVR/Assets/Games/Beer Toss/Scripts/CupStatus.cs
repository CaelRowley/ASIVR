using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CupStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        print(GameObject.FindGameObjectsWithTag("BeerCup").Length);

        if (GameObject.FindGameObjectsWithTag("BeerCup").Length == 0) { SceneManager.LoadScene("MainMenu"); }
    }
}
