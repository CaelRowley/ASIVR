using UnityEngine;
using System.Collections;

public class PlayTimer : MonoBehaviour {
   /*
    public int playTime = 0;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    private int days = 0;
    private int maxScore;

	void Start () {
        StartCoroutine("Timer");
        PlayerPrefs.GetInt("scorePref");
        playTime = PlayerPrefs.GetInt("scorePref");
    }

    private IEnumerator Timer() {
        while(true) {
            yield return new WaitForSeconds(1);
            playTime += 1;
            seconds = playTime % 60;
            minutes = (playTime / 60) % 60;
            hours = (playTime / 3600) % 24;
            days = (playTime / 86400); 
        }
    }

    void Update() {
        PlayerPrefs.SetInt("scorePref", playTime);
    }
    */
}
