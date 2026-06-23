using TMPro;
using UnityEngine;
public class HitCounter : MonoBehaviour
{
    public TMP_Text counterText;

    public int hitCount = 0;
    void Start()
    {
        UpdateText();
    }
    public void AddHit()
    {
        hitCount++;
        UpdateText();
    }
    public void ResetCounter()
    {
        hitCount = 0;
        UpdateText();
    }

    void UpdateText()
    {
        counterText.text = "Hits: " + hitCount;
    }

    public int getHits() 
    {
        return hitCount;
    }
}
