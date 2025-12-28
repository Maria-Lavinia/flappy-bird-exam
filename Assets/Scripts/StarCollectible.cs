using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            logic.DoubleScoreNow();
            Destroy(gameObject);
        }
    }
}
