using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
   public float audioLength;
   public AudioClip[] audioClips = new AudioClip[2];

   private double nextLoopTime;
   private int currentIndex = 0;
   private AudioSource[] audioSources = new AudioSource[2];

   // Creates audio sources as children to Player
   void Start() {
      for(int i = 0; i < 2; i++) {
         GameObject child = new GameObject("Player");
         child.transform.parent = gameObject.transform;
         audioSources[i] = child.AddComponent<AudioSource>();
      }
      nextLoopTime = AudioSettings.dspTime + 1.0f;
   }

   // Plays audio clip after the loop time and switches the index for the next audio clip
   void Update() {
      double currentTime = AudioSettings.dspTime;
      if(currentTime > nextLoopTime) {
         audioSources[currentIndex].clip = audioClips[currentIndex];
         audioSources[currentIndex].PlayScheduled(nextLoopTime);
         nextLoopTime += audioLength;
         currentIndex = 1 - currentIndex;
      }
   }
}
