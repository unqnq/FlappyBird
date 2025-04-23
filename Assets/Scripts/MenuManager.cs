using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private GameObject aboutPanel;
    private GameObject soundPanel;
    private GameObject languagePanel;
    void Start()
    {
        if (GameObject.Find("CoinText") != null)
        {
            GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("maxCoin", 0).ToString();
        }
        aboutPanel = GameObject.Find("AboutPanel");
        aboutPanel.SetActive(false);
        soundPanel = GameObject.Find("SoundPanel");
        soundPanel.SetActive(false);
        languagePanel = GameObject.Find("LanguagePanel");
        languagePanel.SetActive(false);
        // GameObject.Find("AboutText").GetComponent<TextMeshProUGUI>().text = "🐦 Як грати в Flappy Bird \n Натискай на екран або клацай мишкою, щоб пташка летіла вгору.Пролітай між трубами й уникай зіткнень.За кожну пройдену пару труб ти отримуєш 1 очко.🎯 Спробуй набрати якомога більше балів!";
    }
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void ExitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void AboutButton()
    {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }
    public void SoundButton()
    {
        soundPanel.SetActive(!soundPanel.activeSelf);
    }
    public void LanguageButton()
    {
        languagePanel.SetActive(!languagePanel.activeSelf);
    }

}
