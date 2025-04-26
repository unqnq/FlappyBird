using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sounds")]
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip crashSound;
    public AudioClip clickSound;

    [Header("Music")]
    public AudioClip backgroundMusic;

    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Не знищувати між сценами
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Створюємо два AudioSource: для звуків і для музики
        soundSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();

        // Налаштовуємо музичний AudioSource
        musicSource.loop = true;
        musicSource.volume = 0.5f; // можна налаштувати гучність
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            soundSource.PlayOneShot(clip);
        }
    }

    public void PlayJump() => PlaySound(jumpSound);
    public void PlayScore() => PlaySound(scoreSound);
    public void PlayCrash() => PlaySound(crashSound);
    public void PlayClick() => PlaySound(clickSound);

    public void PlayMusic()
    {
        if (backgroundMusic != null && !musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
