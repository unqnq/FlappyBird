using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Mixer Groups")]
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;

    [Header("Sounds")]    
    private AudioSource sfxSource;
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip crashSound;
    public AudioClip clickSound;

    [Header("Music")]
    private AudioSource musicSource;
    public AudioClip backgroundMusic;

    private void Awake()
    {
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
        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();

        if (sfxGroup != null)
        {
            sfxSource.outputAudioMixerGroup = sfxGroup;
        }
        if (musicGroup != null)
        {
            musicSource.outputAudioMixerGroup = musicGroup;
        }
        musicSource.loop = true;
        musicSource.volume = 0.5f;
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
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
