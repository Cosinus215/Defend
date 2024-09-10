using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager instance;
    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
