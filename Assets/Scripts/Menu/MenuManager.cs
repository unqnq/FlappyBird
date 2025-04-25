using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    void Start()
    {
        if (GameObject.Find("CoinText") != null)
        {
            GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("maxCoin", 0).ToString();
        }
        
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
    

}
