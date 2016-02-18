using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTrack : MonoBehaviour {
   public float endOfTrackZValue;
   public Transform trackPrefab;
   public int numOfTracks = 5;
   public float trackSpeed;

   private LinkedList<Transform> trackList = new LinkedList<Transform>();
   private GameObject player;
   private RunnerScoreManager runnerScore;

   void Start() {
      player = GameObject.Find("Player");
      runnerScore = player.GetComponent<RunnerScoreManager>();
      trackSpeed = -trackSpeed;
      Transform track = null;

      // Creates and positions the tracks
      for(int i = 0; i < numOfTracks; i++) {
         track = Instantiate(trackPrefab) as Transform;
         track.Translate(0, 0, i * track.localScale.z);
         trackList.AddLast(track);
      }
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
      }

      // Moves each track forward
      foreach(Transform track in trackList) {
         track.Translate(0, 0, (trackSpeed - runnerScore.currentScore) * Time.deltaTime);
      }
   }
}