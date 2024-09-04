using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    
    public void ToggleGameObject(GameObject objectToActivate) {
        PlayButtonClickSound();
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }

    public void TogglePauseGame(Transform buttonsPanel) {
        Time.timeScale = (Time.timeScale == 1f) ? 0.0f : 1.0f;
        ToggleAllSpawnUnitsButtons(buttonsPanel);
    }

    public void ToggleAllSpawnUnitsButtons(Transform buttonsPanel) {
        PlayButtonClickSound();
        foreach (Button btn in buttonsPanel.GetComponentsInChildren<Button>()) {
            if (btn != buttonsPanel) {
                btn.interactable = !btn.interactable;
            }
        }
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
