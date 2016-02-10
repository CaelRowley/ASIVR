using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTrack : MonoBehaviour {

   public Transform prefab;

   private LinkedList<Transform> tracks = new LinkedList<Transform>();

   private float posY = 0.0f;
   private int numOfTracks = 3;

   // Use this for initialization 
   void Start() {
      // Init the scene with some road-pieces 
      for(int i = 0; i < numOfTracks; i++) {
         Transform track = Instantiate(prefab) as Transform;
         track.Translate(0, 0, i * track.localScale.z);
         print(track.transform.position);
         tracks.AddLast(track);
      }
   }
   // Update is called once per frame 
   void Update() {

      Transform firstTrack = tracks.First.Value;
      Transform lastTrack = tracks.Last.Value;

      if(firstTrack.localPosition.z < -5f) {
         tracks.Remove(firstTrack);
         Destroy(firstTrack.gameObject);

         Transform newTrack = Instantiate(prefab, new Vector3(0, 
                                                              posY, 
                                                              lastTrack.localPosition.z + lastTrack.localScale.z), 
                                                              Quaternion.identity) as Transform;
         tracks.AddLast(newTrack);
      }

      // Create a new road if the first one is not 
      // in sight anymore and destroy the first 
      foreach(Transform road in tracks) {
         road.Translate(0, 0, -8f * Time.deltaTime);
      }
   }
}