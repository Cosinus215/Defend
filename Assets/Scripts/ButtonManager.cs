using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ButtonManager", menuName = "ButtonManager/New ButtonManager")]
public class ButtonManager : ScriptableObject {

    public void LoadNewScene(string scene) {
        SceneManager.LoadScene(scene);
    }
    
    public void ToggleGameObject(GameObject objectToActivate) {
        objectToActivate.SetActive(!objectToActivate.activeSelf);

    }

    public void ExitGame() {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #endif

    }
}
