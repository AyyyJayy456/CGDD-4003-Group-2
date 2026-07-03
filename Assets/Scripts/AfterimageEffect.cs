using UnityEngine;

public class AfterimageEffect : MonoBehaviour
{
    private SpriteRenderer sr;
    private float alpha;
    private float fadeSpeed;
    private Color color;

    public void Init(Sprite ballSprite, Transform ballTransform, float activeTime, float speed)
    {
        sr = GetComponent<SpriteRenderer>();

        
        sr.sprite = ballSprite;
        transform.position = ballTransform.position;
        transform.rotation = ballTransform.rotation;
        transform.localScale = ballTransform.localScale;

       
        alpha = 1f;
        fadeSpeed = speed;
        color = sr.color;


        Destroy(gameObject, activeTime);
    }

    void Update()
    {

        alpha -= fadeSpeed * Time.deltaTime;
        color.a = alpha;
        sr.color = color;
    }
}