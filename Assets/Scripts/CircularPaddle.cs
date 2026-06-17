using UnityEngine;
using UnityEngine.InputSystem;

public class CircularPaddle : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 150f;
    private float currentAngle = 90f;

    void Update()
    {
        float input = 0f;

        // 2. Read the keyboard directly using the new Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                input = -1f;
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                input = 1f;
            }
        }

        // The rest of your circular movement logic remains exactly the same
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
}