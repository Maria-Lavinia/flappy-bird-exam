using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [Header("Score")]
    public int playerScore = 0;
    public Text scoreText;

    [Header("High Score")]
    public Text highScoreText;
    private int bestScore = 0;

    [Header("Game Over UI")]
    public GameObject gameOverScreen;

    [Header("Bird (for color change)")]
    public HighScoreColorChanger birdHighScoreColor;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreUI();
        UpdateHighScoreUI();
    }

    public void addScore(int points)
    {
        playerScore += points;
        UpdateScoreUI();
        CheckAndSaveBest();
    }

    // ⭐ Call this when a star is collected
    public void DoubleScoreNow()
    {
        playerScore *= 2;
        UpdateScoreUI();
        CheckAndSaveBest();
    }

    private void CheckAndSaveBest()
    {
        if (playerScore > bestScore)
        {
            bestScore = playerScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();

            if (birdHighScoreColor != null)
                birdHighScoreColor.OnScoreChanged(playerScore);
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = playerScore.ToString();
    }

    private void UpdateHighScoreUI()
    {
        if (highScoreText != null)
            highScoreText.text = "Best: " + bestScore.ToString();
    }
}
