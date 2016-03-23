using UnityEngine;
using System.Collections;

public class ScaleObject : MonoBehaviour {
   public float targetScaleX;
   public float targetScaleY;
   public float targetScaleZ;
   public float scaleTime;

   void Start() {
      StartCoroutine(ScaleOverTime(scaleTime));
   }

   // Scales the object over the given time then destroys the object
   IEnumerator ScaleOverTime(float time) {
      Vector3 originalScale = gameObject.transform.localScale;
      Vector3 targetScale = new Vector3(targetScaleX, targetScaleY, targetScaleZ);
      float currentTime = 0.0f;

      do {
         gameObject.transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / time);
         currentTime += Time.deltaTime;
         yield return null;
      }
      while(currentTime <= time);

      Destroy(gameObject);
   }
}
