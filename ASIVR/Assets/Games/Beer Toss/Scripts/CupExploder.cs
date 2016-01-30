﻿using UnityEngine;
using System.Collections;

public class CupExploder : MonoBehaviour {

    public float collisionRequired = 1.0f;
    private float collisionCurrent = 0.0f;

    void OnCollisionEnter(Collision col)
    {
        collisionCurrent += Time.deltaTime;

        if (collisionCurrent > collisionRequired) {
            Destroy(col.gameObject);
            Destroy(gameObject);
        } 
    }
}