using UnityEngine;
using UnityEngine.InputSystem;

public class VersusPlayerControl : MonoBehaviour
{
    public Transform Centerpoint;
    public float speedy = 150f;
    public float Currentangle = 90f;
    void Update()
    {
        float input = 0f;
        if (gameObject.CompareTag("Player1"))
        {
            if (Keyboard.current != null)
            {
                if (Keyboard.current.leftArrowKey.isPressed)
                {
                    input = -1.5f;
                }
                else if (Keyboard.current.rightArrowKey.isPressed)
                {
                    input = 1.5f;
                }
            }

            if (input != 0)
            {
                Currentangle -= input * speedy * Time.deltaTime;

                float radius = 5f;
                float x = Centerpoint.position.x + Mathf.Cos(Currentangle * Mathf.Deg2Rad) * radius;
                float y = Centerpoint.position.y + Mathf.Sin(Currentangle * Mathf.Deg2Rad) * radius;

                transform.position = new Vector3(x, y, 0f);

                Vector3 directionToCenter = Centerpoint.position - transform.position;
                float targetRotation = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, targetRotation + 90f);
            }
        }
        if (gameObject.CompareTag("Player2"))
        {
            if (Keyboard.current != null)
            {
                if (Keyboard.current.aKey.isPressed)
                {
                    input = -1.5f;
                }
                else if (Keyboard.current.dKey.isPressed)
                {
                    input = 1.5f;
                }
            }

            if (input != 0)
            {
                Currentangle -= input * speedy * Time.deltaTime;

                float radius = 5f;
                float x = Centerpoint.position.x + Mathf.Cos(Currentangle * Mathf.Deg2Rad) * radius;
                float y = Centerpoint.position.y + Mathf.Sin(Currentangle * Mathf.Deg2Rad) * radius;

                transform.position = new Vector3(x, y, 0f);

                Vector3 directionToCenter = Centerpoint.position - transform.position;
                float targetRotation = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, targetRotation + 90f);
            }
        }
    }
}