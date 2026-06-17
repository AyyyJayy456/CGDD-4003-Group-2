using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        transform.position = Vector3.zero; // Start at center
        // Shoot in a random downward direction to start
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
        rb.linearVelocity = randomDirection * initialSpeed;
    }
    public float maxRadius = 6f; // Slightly past where the paddle sits

    void Update()
    {
        // If the ball goes beyond the paddle radius, player loses the round
        if (Vector3.Distance(transform.position, Vector3.zero) > maxRadius)
        {
            Debug.Log("Out of bounds! Resetting...");
            LaunchBall(); // Reset ball to center
                          // (Add your scoring reduction or UI update logic here later)
        }
    }
}