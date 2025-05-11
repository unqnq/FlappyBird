using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        float musicVolume;
        if (audioMixer.GetFloat("MusicVolume", out musicVolume))
        {
            musicSlider.value = Mathf.Pow(10, musicVolume / 20f);
        }

        float sfxVolume;
        if (audioMixer.GetFloat("SFXVolume", out sfxVolume))
        {
            sfxSlider.value = Mathf.Pow(10, sfxVolume / 20f);
        }
        
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
    }

    public void AddMusic()
    {
        musicSlider.value = musicSlider.value + 0.1f > 1 ? 1 : musicSlider.value + 0.1f;
        SetMusicVolume(musicSlider.value);
    }
    public void SubMusic()
    {
        musicSlider.value = musicSlider.value - 0.1f < 0 ? 0 : musicSlider.value - 0.1f;
        SetMusicVolume(musicSlider.value);
    }
    public void AddSFX()
    {
        sfxSlider.value = sfxSlider.value + 0.1f > 1 ? 1 : sfxSlider.value + 0.1f;
        SetSFXVolume(sfxSlider.value);
    }
    public void SubSFX()
    {
        sfxSlider.value = sfxSlider.value - 0.1f < 0 ? 0 : sfxSlider.value - 0.1f;
        SetSFXVolume(sfxSlider.value);
    }
}
