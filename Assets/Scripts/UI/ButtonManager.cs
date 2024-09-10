using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ButtonManager", menuName = "ButtonManager/New ButtonManager")]
public class ButtonManager : ScriptableObject {
    [SerializeField] private AudioClip clickSound;

    public void LoadNewScene(string scene) {
        PlayButtonClickSound();
        SceneManager.LoadScene(scene);
    }

    public void SwitchMusic(AudioClip backgroundMusic) {
        MusicManager.instance.PlayMusic(backgroundMusic);
    }
    
    public void ToggleMusic() {
        bool audioSourceEnabled = 
            MusicManager.instance.GetAudioSource().enabled;

        MusicManager.instance.GetAudioSource().enabled = !audioSourceEnabled;
    }
    
    public void ToggleSoundEffects() {
        bool audioSourceEnabled =
           SoundManager.instance.GetAudioSource().enabled;

        SoundManager.instance.GetAudioSource().enabled = !audioSourceEnabled;
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
