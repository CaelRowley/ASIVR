using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioInput : MonoBehaviour {
   public int sampleSize = 128;

   private AudioSource audioSource;
   private bool isActive = false;

   // Initialises the default microphone and starts recording
   private void InitialiseMicrophone() {
      audioSource = GetComponent<AudioSource>();
      audioSource.clip = Microphone.Start(null, true, 1, 44100);
      audioSource.loop = true;
      // Waits for recording to start
      while(!(Microphone.GetPosition(null) > 0)) { }
      audioSource.Play();
   }

   // Intialises the microphone and sets isActive to true
   private void Start() {
      InitialiseMicrophone();
      isActive = true;
   }

   // Returns the average volume of the current microphone input
   public float GetAverageVolume() {
      float[] audioData = new float[sampleSize];
      float averageVolume = 0.0f;

      audioSource.GetOutputData(audioData, 0);
      foreach(float currentVolume in audioData) {
         averageVolume += Mathf.Abs(currentVolume);
      }

      return averageVolume / sampleSize;
   }

   // Initialises microphone when app is focused and stops it when app is not focused
   private void OnApplicationFocus(bool inFocus) {
      if(inFocus) {
         if(!isActive) {
            InitialiseMicrophone();
            isActive = true;
         }
      } else if(!inFocus) {
         StopMicrophone();
         isActive = false;
      }
   }

   private void OnDisable() {
      StopMicrophone();
   }

   private void OnDestroy() {
      StopMicrophone();
   }

   private void StopMicrophone() {
      Microphone.End(null);
   }
}
