using UnityEngine;

public class VRSettings : MonoBehaviour {

   void Start() {
      string toggleVRModeKey = "toggleVRMode";
      bool VRMode = PlayerPrefs.GetInt(toggleVRModeKey) == 1 ? true : false;
      Cardboard.SDK.VRModeEnabled = VRMode;
   }
}
