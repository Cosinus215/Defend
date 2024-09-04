using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public LevelTemplate levelTemplate;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
}
