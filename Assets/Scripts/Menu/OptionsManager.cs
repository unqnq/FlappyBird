using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    private GameObject aboutPanel;
    private GameObject soundPanel;
    private GameObject languagePanel;
    void Start()
    {
        aboutPanel = GameObject.Find("AboutPanel");
        aboutPanel.SetActive(false);
        soundPanel = GameObject.Find("SoundPanel");
        soundPanel.SetActive(false);
        languagePanel = GameObject.Find("LanguagePanel");
        languagePanel.SetActive(false);
    }

    public void AboutButton()
    {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
        soundPanel.SetActive(false);
        languagePanel.SetActive(false);
    }
    public void SoundButton()
    {
        soundPanel.SetActive(!soundPanel.activeSelf);
        aboutPanel.SetActive(false);
        languagePanel.SetActive(false);
    }
    public void LanguageButton()
    {
        languagePanel.SetActive(!languagePanel.activeSelf);
        aboutPanel.SetActive(false);
        soundPanel.SetActive(false);
    }
}
