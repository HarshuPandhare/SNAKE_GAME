using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject gamescore;

    public GameObject gameOverPanel;
    public TMP_Text scoreText1;


   
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamescore score = FindAnyObjectByType<gamescore>();
        scoreText1.text = "SCORE : " + score.score.ToString();
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}