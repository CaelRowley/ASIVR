using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
   public Rigidbody enemy;
   public float rotationX;
   public float rotationY;
   public float rotationZ;

   public float offsetRadius = 0;
   public float offsetSphereX;
   public float offsetSphereY;
   public float offsetSphereZ;
   public float spawnTimer;

   private Quaternion rotation;

   void Start() {
      StartCoroutine("SpawnEnemyOutsideRadius");
   }

   // Spawns enemy in a random sphere outside a certain radius
   private IEnumerator SpawnEnemyOutsideRadius() {
      while(true) {
         yield return new WaitForSeconds(spawnTimer);

         Vector3 offsetSphere = new Vector3(Random.Range(-offsetSphereX, offsetSphereX),
                                            Random.Range(-offsetSphereY, offsetSphereY),
                                            Random.Range(-offsetSphereZ, offsetSphereZ));
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
