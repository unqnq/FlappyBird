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
    public int score;
    [SerializeField] private int maxScore;
    private TextMeshProUGUI scoreText;
    private GameObject gameOverImage;
    private GameObject restartButton;
    void Start()
    {
        score = 0;
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        getReadyImage = GameObject.Find("GetReadyImage");
        numberImage = GameObject.Find("NumberImage");
        numberImageComponent = numberImage.GetComponent<RawImage>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameOverImage = GameObject.Find("GameOverImage");
        gameOverImage.SetActive(false);
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
        StartCoroutine(CountdownRoutine());
    }
    public void GameOver()
    {
        PlayerPrefs.SetInt("MaxScore", score);
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
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

}
