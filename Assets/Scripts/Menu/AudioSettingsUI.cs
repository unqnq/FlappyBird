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
}
