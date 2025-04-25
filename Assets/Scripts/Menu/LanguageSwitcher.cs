using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections;

public class LanguageSwitcher : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    void Start()
    {
        int savedLangIndex = PlayerPrefs.GetInt("SelectedLanguage", 0);
        languageDropdown.value = savedLangIndex;
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        StartCoroutine(SetLanguageByIndex(savedLangIndex));
    }

    void OnDestroy()
    {
        languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
    }

    void OnLanguageChanged(int index)
    {
        PlayerPrefs.SetInt("SelectedLanguage", index);
        StartCoroutine(SetLanguageByIndex(index));
    }

    private IEnumerator SetLanguageByIndex(int index)
    {
        yield return LocalizationSettings.InitializationOperation;
        string code = index == 0 ? "uk" : "en";
        var selected = LocalizationSettings.AvailableLocales.Locales
            .Find(locale => locale.Identifier.Code == code);
        LocalizationSettings.SelectedLocale = selected;
    }
}
