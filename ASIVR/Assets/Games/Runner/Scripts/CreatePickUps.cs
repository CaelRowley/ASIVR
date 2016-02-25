using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatePickUps : MonoBehaviour {
   public float endOfTrackZValue;
   public Transform[] pickUpPrefabs;
   public int numOfPickUpsToSpawn;
   public float spawnTime;
   public float trackSpeed;
   public float maxHeight;
   public float minHeight;

   private float spawnTimer;
   private List<Transform> pickUpList = new List<Transform>();

   private float trackLength;
   private float trackWidth;
   private int numOfTracks;
   

   private GameObject player;
   private RunnerScoreManager runnerScoreManager;

   IEnumerator Start() {
      spawnTimer = spawnTime;
      player = GameObject.Find("Player");
      runnerScoreManager = player.GetComponent<RunnerScoreManager>();
      trackSpeed = -trackSpeed;

      yield return new WaitForSeconds(0.1f);

      trackLength = GameObject.FindGameObjectWithTag("Track").transform.localScale.z;
      trackWidth = GameObject.FindGameObjectWithTag("Track").transform.localScale.x;
      numOfTracks = GameObject.FindGameObjectsWithTag("Track").Length;
   }

   void Update() {
      // Calls SpawnObstacles() when the time is up
      spawnTimer -= Time.deltaTime;
      if(spawnTimer <= 0) {
         spawnTimer = 0;
         SpawnObstacles();
      }

      // Destroys pick ups if it is past the end of the track
      Transform[] currentPickUps = pickUpList.ToArray();
      for(int i = 0; i < currentPickUps.Length; i++) {
         if(currentPickUps[i].localPosition.z < endOfTrackZValue) {
            pickUpList.RemoveAt(i);
            Destroy(currentPickUps[i].gameObject, 1);
         }
      }

      // Moves each pick up forward
      foreach(Transform pickUp in pickUpList) {
         pickUp.transform.Translate(0, 0, (trackSpeed - runnerScoreManager.currentScore) * Time.deltaTime);
      }
   }

   private void SpawnObstacles() {
      // Resets timer
      spawnTimer = spawnTime;

      // Spawns the pick ups and adds them to the pick up list
      for(int i = 0; i < numOfPickUpsToSpawn; i++) {
         Transform pickUp = Instantiate(pickUpPrefabs[Random.Range(0, pickUpPrefabs.Length)]) as Transform;
         pickUp.transform.Translate(Random.Range(-trackWidth/2, trackWidth/2), Random.Range(minHeight, maxHeight), (numOfTracks * trackLength) - Random.Range(0, trackLength));
         pickUpList.Add(pickUp);
      }
   }
}
