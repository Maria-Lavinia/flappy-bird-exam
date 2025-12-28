using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public Text resultText;

    [Header("Bird (for color change)")]
    public HighScoreColorChanger birdHighScoreColor;

    private bool ended = false;
    private Coroutine endRoutine;

    void Start()
    {
        Time.timeScale = 1f;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreUI();
        UpdateHighScoreUI();

        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }

    public bool HasEnded() => ended;

    public void addScore(int points)
    {
        if (ended) return;

        playerScore += points;
        UpdateScoreUI();
        CheckAndSaveBest();
    }

    // Call this when a star is collected
    public void DoubleScoreNow()
    {
        if (ended) return;
        FindObjectOfType<SoundManager>()?.PlayStar();
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

    public void LoseAfterDelay(float delaySeconds)
    {
        if (ended) return;
        FindObjectOfType<SoundManager>()?.PlayLose();
        if (endRoutine != null) StopCoroutine(endRoutine);
        endRoutine = StartCoroutine(EndAfterDelay(delaySeconds, "You Lose!"));
    }

    public void Win()
    {
        if (ended) return;
        FindObjectOfType<SoundManager>()?.PlayWin();

        ended = true;

        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        if (resultText != null)
            resultText.text = "You Win!";

        Time.timeScale = 0f;
    }

    private IEnumerator EndAfterDelay(float delaySeconds, string message)
    {
        ended = true;

        if (delaySeconds > 0f)
            yield return new WaitForSecondsRealtime(delaySeconds);

        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        if (resultText != null)
            resultText.text = message;

        Time.timeScale = 0f;
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
