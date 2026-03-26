using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject pauseButton;
    public GameObject instructions;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        panel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        instructions.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(2);
    }

    public void BackStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
