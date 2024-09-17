using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ButtonManager", menuName = "ButtonManager/New ButtonManager")]
public class ButtonManager : ScriptableObject {
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private Settings settings;

    public void LoadNewScene(string scene) {
        PlayButtonClickSound();
        SceneManager.LoadScene(scene);
    }

    public void SwitchMusic(AudioClip backgroundMusic) {
        MusicManager.instance.PlayMusic(backgroundMusic);
    }
    
    public void SoundSlider(float value) {
        SoundManager.instance.GetAudioSource().volume = value;
    }

    public void MusicSlider(float value) {        
        MusicManager.instance.GetAudioSource().volume = value;
    }

    public void ToggleMusic() {
        if (settings.isLoaded == false) return;

        bool audioSourceMuted = 
            MusicManager.instance.GetAudioSource().mute;

        MusicManager.instance.GetAudioSource().mute = !audioSourceMuted;

        settings.isBackgroundMusicOn = audioSourceMuted;
    }
    
    public void ToggleSoundEffects() {
        if (settings.isLoaded == false) return;

        bool audioSourceMuted =
           SoundManager.instance.GetAudioSource().mute;

        SoundManager.instance.GetAudioSource().mute = !audioSourceMuted;

        settings.isSoundEffectOn = audioSourceMuted;
    }

    public void ChangeGraphicsSetting(int graphicsLevel) {
        graphicsLevel = Mathf.Clamp(graphicsLevel, 0, QualitySettings.names.Length - 1);
        QualitySettings.SetQualityLevel(graphicsLevel, true);
    }

    public void ToggleGameObject(GameObject objectToActivate) {
        PlayButtonClickSound();
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }

    public void TogglePauseGame(CanvasGroup canvasGroup) {
        Time.timeScale = (Time.timeScale == 1f) ? 0.0f : 1.0f;
        canvasGroup.interactable = !canvasGroup.interactable;
    }

    public void ExitGame() {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #endif
    }

    private void PlayButtonClickSound() {
        if (clickSound == null) return;

        SoundManager.instance.PlaySound(clickSound);
    }
}
