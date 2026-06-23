using TMPro;
using UnityEngine;

public class VictoryResults : MonoBehaviour
{
    public VersusCounter versusCounter;
    public TMP_Text versusText;

    void Start()
    {
        if (GameData.player1 > GameData.player2)
        {
            versusText.text = "Player 1 Wins!!!";
        }
        else 
        {
            versusText.text = "Player 2 Wins!!!";
        }
    }
}