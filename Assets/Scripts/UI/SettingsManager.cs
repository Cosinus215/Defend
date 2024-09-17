using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    [SerializeField] private Settings settings;
    [SerializeField] private Toggle backgroundMusicToggle;
    [SerializeField] private Toggle SoundEffectsToggle;

    private void OnEnable() {
        backgroundMusicToggle.isOn = settings.isBackgroundMusicOn;
        SoundEffectsToggle.isOn = settings.isSoundEffectOn;
        settings.isLoaded = true;
    }

    private void OnDisable() {
        settings.isLoaded = false;
    }
}
