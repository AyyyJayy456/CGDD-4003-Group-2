using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CoopMovement : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    public HitCounter hitCounter;
    public int increase = 10;

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
        hitCounter.ResetCounter();
    }

    void LaunchBall()
    {
        transform.position = Vector3.zero; 
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
        rb.linearVelocity = randomDirection * initialSpeed;
    }
    public float maxRadius = 6f;

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
    }
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

        int hits = hitCounter.getHits();
        if (hits == increase)
        {
            rb.linearVelocity *= 1.2f;
            increase += 10;
        }
        if (Vector3.Distance(transform.position, Vector3.zero) > maxRadius)
        {
            GameData.finalScore = hitCounter.getHits();

            UnityEngine.SceneManagement.SceneManager.LoadScene("Co-op_Scene");
        }
    }
}