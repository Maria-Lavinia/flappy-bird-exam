using UnityEngine;
using UnityEngine.UI;

public class TimeAttackManager : MonoBehaviour
{
    [Header("References")]
    public LogicScript logic;
    public Text timerText;      
    public Text goalText;       
    public Text resultText;  

    [Header("Time Attack Settings")]
    public bool useTimeAttack = true;
    public int targetScore = 10;
    public float timeLimit = 30f;

    private float timer;
    private bool hasEnded = false;

    void Start()
    {
        if (!useTimeAttack) return;

        timer = timeLimit;

        if (goalText != null)
            goalText.text = "Get " + targetScore + " points in " + timeLimit.ToString("0") + "s";

        UpdateTimerUI();
    }

    void Update()
    {
        if (!useTimeAttack || hasEnded) return;

        timer -= Time.deltaTime;
        if (timer < 0f) timer = 0f;

        UpdateTimerUI();

        // Win early if target score reached
        if (logic != null && logic.playerScore >= targetScore)
        {
            Win();
            return;
        }

        // Time's up
        if (timer <= 0f)
        {
            if (logic != null && logic.playerScore >= targetScore)
                Win();
            else
                TimeUpLose();
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Ceil(timer).ToString();
    }

    private void Win()
    {
        if (hasEnded) return;
        hasEnded = true;

        if (logic != null && logic.gameOverScreen != null)
            logic.gameOverScreen.SetActive(true);

        if (resultText != null)
            resultText.text = "You Win!";

        // Optional: freeze
        // Time.timeScale = 0f;
    }

    private void TimeUpLose()
    {
        if (hasEnded) return;
        hasEnded = true;

        if (logic != null && logic.gameOverScreen != null)
            logic.gameOverScreen.SetActive(true);

        if (resultText != null)
            resultText.text = "Time's Up!\nYou Lose!";

        // Optional: freeze
        // Time.timeScale = 0f;
    }
}
