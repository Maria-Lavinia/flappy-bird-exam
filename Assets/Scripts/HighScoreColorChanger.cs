using UnityEngine;

public class HighScoreColorChanger : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer birdRenderer;

    [Header("Colors")]
    public Color normalColor = Color.white;
    public Color newHighScoreColor = Color.yellow;

    private int bestScore;

    void Start()
    {
        // Get the SpriteRenderer component if not assigned in the inspector
        if (birdRenderer == null)
            birdRenderer = GetComponent<SpriteRenderer>();

        // Load the best score from PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        // Start in normal color
        if (birdRenderer != null)
            birdRenderer.color = normalColor;
    }

    // Call this whenever score changes
    public void OnScoreChanged(int currentScore)
    {
        // Only trigger when you BEAT the old best score
        if (currentScore > bestScore)
        {
            // Update the best score
            bestScore = currentScore;
            
            // Save the new best score to PlayerPrefs
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();

            // Change bird color to highlight new high score
            if (birdRenderer != null)
                birdRenderer.color = newHighScoreColor;
        }
    }
}
