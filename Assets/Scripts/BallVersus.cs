using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallVersus : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    public VersusCounter versusCounter;
    int increases = 10;

    [Header("Afterimage Settings")]
    public GameObject afterimagePrefab;
    public float timeBetweenGhosts = 0.05f;  
    public float ghostActiveTime = 0.4f;    
    public float ghostFadeSpeed = 2.5f;      
    private float ghostDelayTimer;
    private SpriteRenderer ballSpriteRenderer;

    [Header("Curve Settings")]
    public float curveForce = 15f;
    private bool isCurving = false;
    private float currentCurveDir = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballSpriteRenderer = GetComponent<SpriteRenderer>();
        LaunchBall();
    }

    void LaunchBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Random.insideUnitCircle.normalized * initialSpeed;

        ClearCurve();
    }
    public float maxRadius = 6f;

    public void ApplyCurve(float direction)
    {
        isCurving = true;
        currentCurveDir = direction;
    }

    void FixedUpdate()
    {
        if (isCurving)
        {
            // Calculate a vector perpendicular to the ball's current velocity
            Vector2 perpendicularDir = new Vector2(-rb.linearVelocity.y, rb.linearVelocity.x).normalized;

            // Apply force to bend the trajectory
            rb.AddForce(perpendicularDir * (curveForce * currentCurveDir));
        }
    }

    public void ClearCurve()
    {
        isCurving = false;
    }

    void Update()
    {
        if (ghostDelayTimer <= 0)
        {
            SpawnAfterimage();
            ghostDelayTimer = timeBetweenGhosts;
        }
        else
        {
            ghostDelayTimer -= Time.deltaTime;
        }

        int hittings = versusCounter.getHits();
        if (hittings == increases)
        {
            rb.linearVelocity *= 1.2f;
            increases += 10;
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

            ghostScript.Init(ballSpriteRenderer.sprite, transform, ghostActiveTime, ghostFadeSpeed);
        }
    }

    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip scoreSound;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        if (collision.gameObject.CompareTag("Score1"))
        {
            versusCounter.Score1();
            audioSource.PlayOneShot(scoreSound);
            versusCounter.ResetCounter();
            LaunchBall();
        }
        if (collision.gameObject.CompareTag("Score2")) 
        {
            versusCounter.Score2();
            audioSource.PlayOneShot(scoreSound);
            versusCounter.ResetCounter();
            LaunchBall();
        }

        
    }
}