using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    public HitCounter hitCounter;

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

    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > maxRadius)
        {
            GameData.finalScore = hitCounter.getHits();

            UnityEngine.SceneManagement.SceneManager.LoadScene("Results_Scene");
        }
    }
}
