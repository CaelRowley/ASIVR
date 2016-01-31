using UnityEngine;
using System.Collections;

public class DrunkSwayEffect : MonoBehaviour {

    private float loopDuration = 30.0f;
    private float shakeSpeed = 0.0f;
    private float shakeForce = 0.0f;
    private int maxCups;
    public float drinkSpeedEffect = 1.0f;
    public float drinkForceEffect = 0.1f;

    public void StartShake() {
        StopAllCoroutines();
        StartCoroutine("Shake");
    }

    public void Start() {
        maxCups = GameObject.FindGameObjectsWithTag("BeerCup").Length;
    }

    public void Update() {
        int currentCups = GameObject.FindGameObjectsWithTag("BeerCup").Length;

        if (currentCups < maxCups) {
            shakeSpeed += drinkSpeedEffect;
            shakeForce += drinkForceEffect;
            maxCups--;
            StartShake();
        }         
    }

    IEnumerator Shake()
    {
        float time = 0.0f;
        Vector3 originalCamPos = Camera.main.transform.position;
        float randomStart = Random.Range(-1000.0f, 1000.0f);

        while (time < loopDuration) {
            time += Time.deltaTime;
            float intensity = time / loopDuration;
            float damper = 1.0f - Mathf.Clamp(2.0f * intensity - 1.0f, 0.0f, 1.0f);
            float sway = randomStart + shakeSpeed * intensity;
            float x = Util.SimplexNoise.Noise(sway, 0.0f, 0.0f) * 2.0f - 1.0f;
            float y = Util.SimplexNoise.Noise(0.0f, sway, 0.0f) * 2.0f - 1.0f;
            x *= shakeForce * damper;
            y *= shakeForce * damper;
            Camera.main.transform.position = new Vector3(x, y + 1.5f, originalCamPos.z);

            if (time >= loopDuration)
                time = 0.0f;

            yield return null;
        }
        Camera.main.transform.position = originalCamPos;
    }
}
