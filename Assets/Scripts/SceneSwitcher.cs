using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void singleInstruction() 
    {
        SceneManager.LoadScene("SinglePlayerInstruction");
    }
    public void versusInstruction() 
    {
        SceneManager.LoadScene("VersusInstruction");
    }
    public void coopInstruction() 
    {
        SceneManager.LoadScene("CoOpInstruction");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Circular_Pong");
    }

    public void Versus() 
    {
        SceneManager.LoadScene("2Player_Pong");
    }
    public void coOp() 
    {
        SceneManager.LoadScene("2Player_CoOp");
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Circular_Pong");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void ResultsScreen()
    {
        SceneManager.LoadScene("Results_Scene");
    }

    public void VictoryScreen() 
    {
        SceneManager.LoadScene("Victory_Scene");
    }

    public void ReplayGame() 
    {
        SceneManager.LoadScene("2Player_Pong");
    }

    public void RetryCoOp() 
    {
        SceneManager.LoadScene("2Player_CoOp");
    }
    public void Quit()
    {
           Application.Quit();
    }
}