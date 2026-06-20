using TMPro;
using UnityEngine;

public class ResultsUI : MonoBehaviour
{
    public HitCounter hitCounter;
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Final Score: " + GameData.finalScore;
    }
}
