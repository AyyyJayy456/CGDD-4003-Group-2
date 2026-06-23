using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BallVersus : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    public VersusCounter versusCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        int player1 = versusCounter.getPlay1();
        int player2 = versusCounter.getPlay2();
        GameData.player1 = player1;
        GameData.player2 = player2;
        if (player1 == 11 || player2 == 11) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory_Screen");
        }
    }

    public AudioSource audioSource;
    public AudioClip hitSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Score1"))
        {
            versusCounter.Score1();
            LaunchBall();
        }
        else if (collision.gameObject.CompareTag("Score2")) 
        {
            versusCounter.Score2();
            LaunchBall();
        }

        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}