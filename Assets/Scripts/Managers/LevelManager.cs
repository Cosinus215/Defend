using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    [SerializeField] private LevelTemplate levelTemplate;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public LevelTemplate GetLevelTemplate() { 
        return levelTemplate;
    }

    public void SetLevelTemplate(LevelTemplate lTemplate) {
        levelTemplate = lTemplate;
    }
}
