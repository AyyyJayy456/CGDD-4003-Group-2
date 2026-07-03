using UnityEngine;
using UnityEngine.SceneManagement;

public class BallVersus : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    public VersusCounter versusCounter;

    [Header("Afterimage Settings")]
    public GameObject afterimagePrefab;
    public float timeBetweenGhosts = 0.05f;  
    public float ghostActiveTime = 0.4f;    
    public float ghostFadeSpeed = 2.5f;      
    private float ghostDelayTimer;
    private SpriteRenderer ballSpriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballSpriteRenderer = GetComponent<SpriteRenderer>();
        LaunchBall();
    }

    void LaunchBall()
    {
        transform.position = Vector3.zero;
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
        rb.linearVelocity = randomDirection * initialSpeed;
    }
    public float maxRadius = 6f;

    void Update()
    {
        // Handle Afterimage Spawning
        if (ghostDelayTimer <= 0)
        {
            SpawnAfterimage();
            ghostDelayTimer = timeBetweenGhosts;
        }
        else
        {
            ghostDelayTimer -= Time.deltaTime;
        }

        int player1 = versusCounter.getPlay1();
        int player2 = versusCounter.getPlay2();
        GameData.player1 = player1;
        GameData.player2 = player2;
        if (player1 == 11 || player2 == 11) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory_Screen");
        }
    }

    void SpawnAfterimage()
    {
        if (afterimagePrefab != null && ballSpriteRenderer != null)
        {
            GameObject ghost = Instantiate(afterimagePrefab);
            AfterimageEffect ghostScript = ghost.GetComponent<AfterimageEffect>();

            // Pass the ball's current data over to the ghost
            ghostScript.Init(ballSpriteRenderer.sprite, transform, ghostActiveTime, ghostFadeSpeed);
        }
    }

    public AudioSource audioSource;
    public AudioClip hitSound;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        if (collision.gameObject.CompareTag("Score1"))
        {
            versusCounter.Score1();
            LaunchBall();
        }
        if (collision.gameObject.CompareTag("Score2")) 
        {
            versusCounter.Score2();
            LaunchBall();
        }

        
    }
}