using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb2d;
    private GameObject gameOverImage;
    [SerializeField] private float delayGameOverTime;
    void Start()
    {
        gameOverImage = GameObject.Find("GameOverImage");
        gameOverImage.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }
    void Jump()
    {
        if (rb2d != null)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameOverImage.SetActive(true);
            Invoke("GameOver", delayGameOverTime);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}
