using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    public HitCounter hitCounter;
    public int increase = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        int hits = hitCounter.getHits();
        if (hits == increase)
        {
            rb.linearVelocity *= 1.2f;
            increase += 10;
        }
        if (Vector3.Distance(transform.position, Vector3.zero) > maxRadius)
        {
            GameData.finalScore = hitCounter.getHits();

            UnityEngine.SceneManagement.SceneManager.LoadScene("Results_Scene");
        }
    }
}