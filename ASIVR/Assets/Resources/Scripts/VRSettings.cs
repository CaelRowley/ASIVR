using UnityEngine;

public class VRSettings : MonoBehaviour {

   private void Start() {
      string toggleVRModeKey = "toggleVRMode";
      bool VRMode = PlayerPrefs.GetInt(toggleVRModeKey) == 1 ? true : false;
      Cardboard.SDK.VRModeEnabled = VRMode;
   }
}
