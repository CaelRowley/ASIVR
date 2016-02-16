﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObstacles : MonoBehaviour {
   public float endOfTrackZValue;
   public Transform[] obstaclePrefabs;
   public int numOfObstaclesToSpawn;
   public float spawnTime;

   private float spawnTimer;
   private List<Transform> obstacleList = new List<Transform>();

   private float trackLength;
   private int numOfTracks;

   void Start() {
      trackLength = GameObject.FindGameObjectWithTag("Track").transform.localScale.z;
      numOfTracks = GameObject.FindGameObjectsWithTag("Track").Length;
      SpawnObstacles();
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
         obstacle.transform.Translate(0, 0, -8f * Time.deltaTime);
      }
   }

   private void SpawnObstacles() {
      // Resets timer
      spawnTimer = spawnTime;

      // Spawns the obstacles and adds them to the obstacle list
      for(int i = 0; i < numOfObstaclesToSpawn; i++) {
         Transform obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]) as Transform;
         obstacle.transform.Translate(0, 0, (numOfTracks * trackLength) - Random.Range(0, trackLength * 2));
         obstacleList.Add(obstacle);
      }
   }
}
