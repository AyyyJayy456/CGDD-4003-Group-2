using TMPro;
using UnityEngine;
public class VersusCounter : MonoBehaviour
{
    public TMP_Text versusText;

    public int play1 = 0;
    public int play2 = 0;
    int hitting = 0;
    void Start()
    {
        UpdateText();
    }
    public void Score1()
    {
        play1++;
        UpdateText();
    }
    public void Score2()
    {
        play2++;
        UpdateText();
    }

    void UpdateText()
    {
        versusText.text = play1 + ":" + play2;
    }

    public int getPlay1()
    {
        return play1;
    }

    public int getPlay2()
    {
        return play2;
    }
    public void AddHit()
    {
        hitting++;
    }
    public void ResetCounter()
    {
        hitting = 0;
    }
    public int getHits() 
    {
        return hitting;
    }
}
