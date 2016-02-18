using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatePickUps : MonoBehaviour {
   public float endOfTrackZValue;
   public Transform[] obstaclePrefabs;
   public int numOfObstaclesToSpawn;
   public float spawnTime;
   public float trackSpeed;

   private float spawnTimer;
   private List<Transform> obstacleList = new List<Transform>();

   private float trackLength;
   private int numOfTracks;

   private GameObject player;
   private RunnerScoreManager runnerScore;

   IEnumerator Start() {
      spawnTimer = spawnTime;
      player = GameObject.Find("Player");
      runnerScore = player.GetComponent<RunnerScoreManager>();
      trackSpeed = -trackSpeed;

      yield return new WaitForSeconds(0.1f);
      
      trackLength = GameObject.FindGameObjectWithTag("Track").transform.localScale.z;
      numOfTracks = GameObject.FindGameObjectsWithTag("Track").Length;
   }

   void Update() {
      spawnTimer -= Time.deltaTime;
      if(spawnTimer <= 0) {
         spawnTimer = 0;
         SpawnObstacles();
      }

      // Destroys obstacle if it is past the end of the track
      Transform[] currentObstacles = obstacleList.ToArray();
      for(int i = 0; i < currentObstacles.Length; i++) {
         if(currentObstacles[i].localPosition.z < endOfTrackZValue) {
            obstacleList.RemoveAt(i);
            Destroy(currentObstacles[i].gameObject, 1);
         }
      }

      // Moves each obstacle forward
      foreach(Transform obstacle in obstacleList) {
         obstacle.transform.Translate(0, 0, (trackSpeed - runnerScore.currentScore) * Time.deltaTime);
      }
   }

   private void SpawnObstacles() {
      // Resets timer
      spawnTimer = spawnTime;

      // Spawns the obstacles and adds them to the obstacle list
      for(int i = 0; i < numOfObstaclesToSpawn; i++) {
         Transform obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]) as Transform;
         obstacle.transform.Translate(Random.Range(-5, 5), Random.Range(2, 3), (numOfTracks * trackLength) - Random.Range(0, trackLength));
         obstacleList.Add(obstacle);
      }
   }
}
