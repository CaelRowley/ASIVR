using UnityEngine;

public class VRModeToggle : MonoBehaviour {

   // Toggles VR mode and saves the settings
   public void ToggleVRMode() {
      string toggleVRModeKey = "toggleVRMode";
      bool VRMode = GetBool(toggleVRModeKey);

      VRMode = !VRMode;
      Cardboard.SDK.VRModeEnabled = VRMode;
      SetBool(toggleVRModeKey, VRMode);
   }

   // Saves the bool as an int in playerPrefs
   static void SetBool(string playerPrefKey, bool boolean) {
      PlayerPrefs.SetInt(playerPrefKey, boolean ? 1 : 0);
   }

   // Reads playerPrefs int as a bool
   private bool GetBool(string playerPrefKey) {
      return PlayerPrefs.GetInt(playerPrefKey) == 1 ? true : false;
   }
}
