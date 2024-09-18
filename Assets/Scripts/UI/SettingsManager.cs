using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    [SerializeField] private Settings settings;
    [SerializeField] private Toggle backgroundMusicToggle;
    [SerializeField] private Slider backgroundMusicSlider;
    [SerializeField] private Toggle soundEffectsToggle;
    [SerializeField] private Slider soundEffectsSlider;
    [SerializeField] private TMP_Dropdown graphicsLevel;

    private void OnEnable() {
        backgroundMusicToggle.isOn = settings.IsBackgroundMusicOn;
        soundEffectsToggle.isOn = settings.IsSoundEffectOn;
        graphicsLevel.value = settings.GraphicsLevel;
        backgroundMusicSlider.value = settings.BackgroundMusicSlider;
        soundEffectsSlider.value = settings.SoundEffectSlider;
        settings.IsLoaded = true;
    }

    private void OnDisable() {
        settings.IsLoaded = false;
    }
}
