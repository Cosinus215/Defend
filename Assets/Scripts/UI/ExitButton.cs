using UnityEngine;

public class ExitButton : MonoBehaviour {

    private void Start() {
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            gameObject.SetActive(false);
        }
    }
}
