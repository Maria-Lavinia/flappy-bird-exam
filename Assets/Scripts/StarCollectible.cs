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
        // If your bird is on layer 3 like your PipeMiddleScript uses:
        if (other.gameObject.layer == 3)
        {
            logic.DoubleScoreNow();
            Destroy(gameObject);
        }
    }
}
