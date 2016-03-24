using UnityEngine;

public class PlayAudio : MonoBehaviour {
   public AudioClip audioClip = new AudioClip();
   private AudioSource audioSource = new AudioSource();

   // Initialises audio
   private void Start() {
      GameObject child = new GameObject("Player");
      child.transform.parent = gameObject.transform;
      audioSource = child.AddComponent<AudioSource>();
   }

   // Plays audio when aimed at
   private void OnPointerEnter() {
      audioSource.PlayOneShot(audioClip);
   }
}
