using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject getReadyImage;
    private GameObject numberImage;
    private RawImage numberImageComponent;
    [SerializeField] private Texture[] num;
    public int coin;
    [SerializeField] private int maxCoin;
    private TextMeshProUGUI scoreText;
    private GameObject gameOverImage;
    private GameObject restartButton;
    private GameObject pauseButton;
    private GameObject resumeButton;
    void Start()
    {
        coin = 0;
        maxCoin = PlayerPrefs.GetInt("maxCoin", 0);
        getReadyImage = GameObject.Find("GetReadyImage");
        numberImage = GameObject.Find("NumberImage");
        numberImageComponent = numberImage.GetComponent<RawImage>();
        scoreText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        gameOverImage = GameObject.Find("GameOverImage");
        gameOverImage.SetActive(false);
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
        pauseButton = GameObject.Find("PauseButton");
        pauseButton.SetActive(true);
        resumeButton = GameObject.Find("ResumeButton");
        resumeButton.SetActive(false);
        StartCoroutine(CountdownRoutine());
    }
    public void GameOver()
    {
        maxCoin += coin;
        PlayerPrefs.SetInt("maxCoin", maxCoin);
        PostProcessVolume ppVolume = Camera.main.GetComponent<PostProcessVolume>();
        if (ppVolume != null)
        {
            ppVolume.enabled = true;
        }
        gameOverImage.SetActive(true);
        restartButton.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     private IEnumerator CountdownRoutine()
    {
        getReadyImage.SetActive(false);
        numberImage.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            numberImageComponent.texture = num[i - 1];
            yield return new WaitForSeconds(1f);
        }

        numberImage.SetActive(false);
        getReadyImage.SetActive(true);

        yield return new WaitForSeconds(1f);
        getReadyImage.SetActive(false);
        FindAnyObjectByType<PipeSpawn>().StartSpawnPipes();
        FindAnyObjectByType<PlayerController>().GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void AddScore(int scoreToAdd)
    {
        coin += scoreToAdd;
        scoreText.text = coin.ToString();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }
}
