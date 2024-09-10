using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
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

    public void PlaySound(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public AudioSource GetAudioSource() {
        return audioSource;
    }
}
