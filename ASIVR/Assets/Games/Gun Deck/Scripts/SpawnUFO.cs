using UnityEngine;
using System.Collections;

public class SpawnUFO : MonoBehaviour {
   public float offsetRadius = 0;
   public Rigidbody enemy;
   public float rotationX;
   public float rotationY;
   public float rotationZ;
   public float spawnTimer;

   private Quaternion rotation;

   void Start() {
      StartCoroutine("SpawnEnemy");
   }

   private IEnumerator SpawnEnemy() {
      while(true) {
         yield return new WaitForSeconds(spawnTimer);

         Vector3 offsetSphere = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

         if(offsetSphere.x >= 0)
            offsetSphere.x += offsetRadius;
         else
            offsetSphere.x -= offsetRadius;

         if(offsetSphere.y >= 0)
            offsetSphere.y += offsetRadius;
         else
            offsetSphere.y -= offsetRadius;

         if(offsetSphere.z >= 0)
            offsetSphere.z += offsetRadius;
         else
            offsetSphere.z -= offsetRadius;

         rotation = transform.rotation * Quaternion.Euler(rotationX, rotationY, rotationZ);

         Instantiate(enemy, transform.position + offsetSphere, rotation);
      }
   }
}
