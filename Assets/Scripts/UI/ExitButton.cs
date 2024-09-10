using UnityEngine;

public class ExitButton : MonoBehaviour {

    private void Start() {
        #if UNITY_WEBGL
            gameObject.SetActive(false);
        #endif
    }
}
