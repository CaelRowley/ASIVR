using UnityEngine;

public class PlayAudio : MonoBehaviour {
   public AudioClip audioClip = new AudioClip();
   private AudioSource audioSource = new AudioSource();

   // Use this for initialization
   void Start() {
      GameObject child = new GameObject("Player");
      child.transform.parent = gameObject.transform;
      audioSource = child.AddComponent<AudioSource>();
   }

   // Update is called once per frame
   void OnPointerEnter() {
      audioSource.PlayOneShot(audioClip);
   }
}
