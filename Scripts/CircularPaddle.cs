using UnityEngine;
using UnityEngine.InputSystem;

public class CircularPaddle : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 150f;
    public float currentAngle = 90f;
    public HitCounter hitCounter;

    void Update()
    {
        float input = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                input = -1.5f;
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                input = 1.5f;
            }
        }

        if (input != 0)
        {
            currentAngle -= input * speed * Time.deltaTime;

            float radius = 5f;
            float x = centerPoint.position.x + Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
            float y = centerPoint.position.y + Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;

            transform.position = new Vector3(x, y, 0f);

            Vector3 directionToCenter = centerPoint.position - transform.position;
            float targetRotation = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, targetRotation + 90f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCounter.AddHit();
        }
    }
}