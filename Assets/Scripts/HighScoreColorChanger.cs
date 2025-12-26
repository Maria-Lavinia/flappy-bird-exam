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
        if (birdRenderer == null)
            birdRenderer = GetComponent<SpriteRenderer>();

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
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();

            if (birdRenderer != null)
                birdRenderer.color = newHighScoreColor;
        }
    }
}
