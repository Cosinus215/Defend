using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ButtonManager", menuName = "ButtonManager/New ButtonManager")]
public class ButtonManager : ScriptableObject {

    public void LoadNewScene(string scene) {
        SceneManager.LoadScene(scene);
    }
    
    public void ToggleGameObject(GameObject objectToActivate) {
        objectToActivate.SetActive(!objectToActivate.activeSelf);

    }

    public void TogglePauseGame(Transform buttonsPanel) {
        Time.timeScale = (Time.timeScale == 1f) ? 0.0f : 1.0f;
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
}
