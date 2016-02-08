using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Radar : MonoBehaviour {

   public GameObject[] trackedObjects;
   public List<GameObject> radarObjects;
   public GameObject radarPrefab;

   void Start() {
      createRadarObjects();
   }

   private void createRadarObjects() {
      radarObjects = new List<GameObject>();

      foreach(GameObject obj in trackedObjects) {
         GameObject k = Instantiate(radarPrefab, obj.transform.position, Quaternion.identity) as GameObject;
         radarObjects.Add(k);
      }
   }


}
