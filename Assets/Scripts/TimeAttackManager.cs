using UnityEngine;
using UnityEngine.UI;

public class TimeAttackManager : MonoBehaviour
{
    [Header("References")]
    public LogicScript logic;
    public Text timerText;
    public Text goalText;

    [Header("Time Attack Settings")]
    public bool useTimeAttack = true;
    public int targetScore = 10;
    public float timeLimit = 30f;

    private float timer;
    private bool hasEnded = false;

    void Start()
    {
        if (!useTimeAttack) return;

        // Initialize the countdown timer
        timer = timeLimit;

        if (goalText != null)
            goalText.text = "Get " + targetScore + " points";

        UpdateTimerUI();
    }

    void Update()
    {
        if (!useTimeAttack || hasEnded) return;
        if (logic == null) return;
        if (logic.HasEnded()) return;

        // Win early if target score reached
        if (logic.playerScore >= targetScore)
        {
            hasEnded = true;
            logic.Win();
            return;
        }

        // Decrease the timer each frame
        timer -= Time.deltaTime;
        if (timer < 0f) timer = 0f;

        UpdateTimerUI();

        // Time's up
        if (timer <= 0f)
        {
            hasEnded = true;
            logic.LoseAfterDelay(0f);
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Ceil(timer).ToString();
    }
}
