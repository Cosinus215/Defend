using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/New Settings")]
public class Settings : ScriptableObject {
    public bool isBackgroundMusicOn { get; set; }
    public bool isSoundEffectOn { get; set; }
    public bool isLoaded { get; set; }

    public void SetEverythingToOn() {
        isBackgroundMusicOn = true;
        isSoundEffectOn = true;
    }

}
