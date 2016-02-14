using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTrack : MonoBehaviour {

   // For the track
   public Transform trackPrefab;
   public int numOfTracks = 5;
   public float trackPosY = 0.0f;

   private LinkedList<Transform> trackList = new LinkedList<Transform>();

   // For the obstacles
   public Transform[] obstacles;
   public float obstaclePosY = 0.0f;

   private LinkedList<Transform> obstacleList = new LinkedList<Transform>();

   void Start() {
      Transform track = null;

      // Creates and postiions the initial tracks
      for(int i = 0; i < numOfTracks; i++) {
         track = Instantiate(trackPrefab) as Transform;
         track.Translate(0, trackPosY, i * track.localScale.z);
         trackList.AddLast(track);
      }

      // Creates and positions the initial obstacles
      for(int i = 0; i < obstacles.Length; i++) {
         Transform obstacle = Instantiate(obstacles[i]) as Transform;
         obstacle.Translate(0, obstaclePosY, (numOfTracks / 2) * track.localScale.z);
         obstacleList.AddLast(obstacle);
      }
   }

   void Update() {
      Transform firstTrack = trackList.First.Value;
      Transform lastTrack = trackList.Last.Value;

      // Removes the first track and adds a new one
      if(firstTrack.localPosition.z < -5.0f) {
         trackList.Remove(firstTrack);
         Destroy(firstTrack.gameObject);

         Transform newTrack = Instantiate(trackPrefab, new Vector3(0,
                                                              trackPosY,
                                                              lastTrack.localPosition.z + lastTrack.localScale.z),
                                                              Quaternion.identity) as Transform;
         trackList.AddLast(newTrack);
      }

      // Moves each track forward
      foreach(Transform track in trackList) {
         track.Translate(0, 0, -8f * Time.deltaTime);
      }

      // Moves obstacle back
      foreach(Transform obstacle in obstacleList) {
         if(obstacle.localPosition.z < -5.0f) {
            obstacle.Translate(0, 0, (numOfTracks / 2) * firstTrack.localScale.z);
         }
      }

      // Moves each obstacle forward
      foreach(Transform obstacle in obstacleList) {
         obstacle.Translate(0, trackPosY, -8f * Time.deltaTime);
      }
   }
}