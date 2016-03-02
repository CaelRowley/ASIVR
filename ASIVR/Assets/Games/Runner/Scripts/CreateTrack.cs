using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTrack : MonoBehaviour {
   public float endOfTrackZValue;
   public Transform trackPrefab;
   public int numOfTracks;
   public float trackSpeed;

   private LinkedList<Transform> trackList = new LinkedList<Transform>();
   private GameObject player;
   private RunnerScoreManager runnerScoreManager;

   public Transform[] obstaclePrefabs;
   public int numOfObstaclesToSpawn;
   private List<Transform> obstacleList = new List<Transform>();
   private float trackLength;

   void Start() {
      player = GameObject.Find("Player");
      runnerScoreManager = player.GetComponent<RunnerScoreManager>();
      Transform track = null;

      // Creates and positions the tracks
      for(int i = 0; i < numOfTracks; i++) {
         track = Instantiate(trackPrefab) as Transform;
         track.Translate(0, 0, i * track.localScale.z);
         trackList.AddLast(track);
      }

      trackLength = track.transform.localScale.z;

      // Initialises obstacles
      SpawnObstacles();
   }

   void Update() {
      Transform firstTrack = trackList.First.Value;
      Transform lastTrack = trackList.Last.Value;

      // Removes the first track and adds a new track to the end
      if(firstTrack.localPosition.z < endOfTrackZValue) {
         trackList.Remove(firstTrack);
         Destroy(firstTrack.gameObject);
         Transform newTrack = Instantiate(trackPrefab,
                                          new Vector3(0, 0, lastTrack.localPosition.z + lastTrack.localScale.z),
                                          Quaternion.identity) as Transform;
         trackList.AddLast(newTrack);

         // Spawns obstacles for the new track
         SpawnObstacles();
      }

      // Moves each track forward
      foreach(Transform track in trackList) {
         track.Translate(0, 0, (trackSpeed - runnerScoreManager.currentScore) * Time.deltaTime);
      }

      // Destroys obstacle if it is past the end of the track
      Transform[] currentObstacles = obstacleList.ToArray();
      for(int i = 0; i < currentObstacles.Length; i++) {
         if(currentObstacles[i].localPosition.z < endOfTrackZValue) {
            obstacleList.RemoveAt(i);
            Destroy(currentObstacles[i].gameObject, 2);
         }
      }

      // Moves each obstacle forward
      foreach(Transform obstacle in obstacleList) {
         obstacle.transform.Translate(0, 0, (trackSpeed - runnerScoreManager.currentScore) * Time.deltaTime);
      }
   }

   private void SpawnObstacles() {
      // Spawns the obstacles and adds them to the obstacle list
      for(int i = 0; i < numOfObstaclesToSpawn; i++) {
         Transform obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]) as Transform;
         obstacle.transform.Translate(0, 0, (numOfTracks * trackLength) - Random.Range(0, (trackLength * 2 / 3)));
         obstacleList.Add(obstacle);
      }
   }
}