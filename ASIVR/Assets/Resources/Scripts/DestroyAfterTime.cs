using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
   public float lifespan;

	// Destroys gameObject after lifespan is up
	void Start () {
      Destroy(gameObject, lifespan);
	}

}
