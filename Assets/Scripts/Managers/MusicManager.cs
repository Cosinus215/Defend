using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager instance;
    private AudioSource audioSource;
    [SerializeField] private Settings settings;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        settings.SetEverythingToOn();
    }

    public void PlayMusic(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public AudioSource GetAudioSource() { 
        return audioSource;
    }
}
