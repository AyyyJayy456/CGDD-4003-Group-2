using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Circular_Pong");
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

    public void Quit()
    {
           Application.Quit();
    }
}