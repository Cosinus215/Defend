using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/New Settings")]
public class Settings : ScriptableObject {
    public bool IsBackgroundMusicOn { get; set; }
    public bool IsSoundEffectOn { get; set; }
    public float BackgroundMusicSlider { get; set; }
    public float SoundEffectSlider { get; set; }
    public int GraphicsLevel { get; set; }
    public bool IsLoaded { get; set; }

    public void SetEverythingToDefault() {
        IsBackgroundMusicOn = true;
        IsSoundEffectOn = true;
        BackgroundMusicSlider = 100;
        SoundEffectSlider = 100;
        GraphicsLevel = 0;
    }

}
