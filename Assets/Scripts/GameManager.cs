using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelGameOverOutBounds;
    public GameObject panelGameOverScore;
    public GameObject pauseButton;
    public GameObject instructions;
    public TMP_InputField playerName;
    public PlayerMove playerMove;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }

    public void GameOverOutBounds()
    {
        Time.timeScale = 0;
        panelGameOverOutBounds.SetActive(true);
        
    }

    public void GameOverScore()
    {
        Time.timeScale = 0;
        panelGameOverScore.SetActive(true);
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

    public void RestartGame()
    {
        if(playerName.text != "")
        {
            Player player = new Player(playerMove.score, playerName.text);
            SystemDataManager.SaveBestScore(player);
            panelGameOverOutBounds.SetActive(false);
            panelGameOverScore.SetActive(false);
            StartGame();
        }
    }

    public void RestartGameOutBunds()
    {
        StartGame();
        panelGameOverOutBounds.SetActive(false);
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
