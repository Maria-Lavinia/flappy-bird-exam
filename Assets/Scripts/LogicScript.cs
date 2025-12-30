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
        // Reset time scale to normal
        Time.timeScale = 1f;

        // Load the best score from PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreUI();
        UpdateHighScoreUI();

        // Hide the game over screen at start
         if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }

    public bool HasEnded() => ended;

    public void AddScore(int points)
    {
        // Don't add score if game has ended
        if (ended) return;

        playerScore += points;
        UpdateScoreUI();
        CheckAndSaveBest();
    }

    // Call this when a star is collected
    public void DoubleScoreNow()
    {
        // Don't double score if game has ended
        if (ended) return;
        
        // Play star sound effect
        if(FindObjectOfType<SoundManager>() != null)
            FindObjectOfType<SoundManager>().PlayStar();
        
        // Double the current score
        playerScore *= 2;
        UpdateScoreUI();
        CheckAndSaveBest();
    }

    private void CheckAndSaveBest()
    {
        // Check if current score is higher than best score
        if (playerScore > bestScore)
        {
            // Update and save the new best score
            bestScore = playerScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();

            // Notify bird color changer of new high score
            if (birdHighScoreColor != null)
                birdHighScoreColor.OnScoreChanged(playerScore);
        }
    }

    public void LoseAfterDelay(float delaySeconds)
    {
        // Don't trigger lose if game has already ended
        if (ended) return;
        
        // Play lose sound effect
        if(FindObjectOfType<SoundManager>() != null)
            FindObjectOfType<SoundManager>().PlayLose();
        
        // Stop any existing end routine and start a new one
        if (endRoutine != null) StopCoroutine(endRoutine);
        endRoutine = StartCoroutine(EndAfterDelay(delaySeconds, "You Lose!"));
    }

    public void Win()
    {
        // Don't trigger win if game has already ended
        if (ended) return;
        
        // Play win sound effect
        if(FindObjectOfType<SoundManager>() != null)
            FindObjectOfType<SoundManager>().PlayWin();

        // Mark game as ended
        ended = true;

        // Show game over screen with win message
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        if (resultText != null)
            resultText.text = "You Win!";

        // Pause the game
        Time.timeScale = 0f;
    }

    private IEnumerator EndAfterDelay(float delaySeconds, string message)
    {
        // Mark game as ended immediately
        ended = true;

        // Wait for the specified delay (using realtime to work with timeScale)
        if (delaySeconds > 0f)
            yield return new WaitForSecondsRealtime(delaySeconds);

        // Show game over screen with the provided message
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        if (resultText != null)
            resultText.text = message;

        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Resume time scale
        Time.timeScale = 1f;
        
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScoreUI()
    {
        // Update score text display
         if (scoreText != null)
            scoreText.text = playerScore.ToString();
    }

    private void UpdateHighScoreUI()
    {
        // Update high score text display
           if (highScoreText != null)
            highScoreText.text = "Best: " + bestScore.ToString();
    }
}
