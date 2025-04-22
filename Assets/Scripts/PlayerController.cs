using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb2d;
    [SerializeField] private float delayGameOverTime;
    public bool isGameOver = false;
    [SerializeField] private GameObject tap;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        tap = GameObject.Find("TapPlayer");
    }
    void Update()
    {
        if (rb2d.gravityScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
            {
                Jump();
                tap.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                tap.transform.position = new Vector3(tap.transform.position.x, tap.transform.position.y, 0);
            }
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            GameObject.Find("PipeSpawn").GetComponent<PipeSpawn>().canSpawn = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0); 
            rb2d.gravityScale = 0;
            FindAnyObjectByType<UIManager>().GameOver();
        }
    }    
    void OnTriggerEnter2D(Collider2D other)
    {
        FindAnyObjectByType<UIManager>().AddScore(1);
    }
}
