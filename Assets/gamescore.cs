using UnityEngine;
using TMPro;

public class gamescore : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

}
