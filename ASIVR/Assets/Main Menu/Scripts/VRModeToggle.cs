using UnityEngine;
using System.Collections;

public class VRModeToggle : MonoBehaviour {

   public void ToggleVRMode() {
      Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
   }
}
