using UnityEngine;
using System.Collections;

public class Player_Throw : MonoBehaviour {
    public Rigidbody projectile;
    public float speed = 5;

    void Start() {
        // Disable screen dimming:
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update() {
        if (Cardboard.SDK.Triggered) {
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                                        transform.position,
                                                                        transform.rotation)
                                                                        as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
