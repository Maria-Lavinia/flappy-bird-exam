using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool isAlive = true;

    public CameraShake cameraShake;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find and cache reference to the LogicScript component
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    
    // Handles the bird's death sequence including camera shake and game over.
    public void Die()
    {
        if (!isAlive) return; // prevent double-trigger
        isAlive = false;

        // Trigger camera shake effect if available
        if (cameraShake != null)
            cameraShake.Shake(0.3f, 0.3f);

        // Trigger lose screen after delay
        logic.LoseAfterDelay(1f);
    }

    // Called every frame. Handles player input and checks for out-of-bounds conditions.
    void Update()
    {
        // Apply upward force when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength; // represents 0,1, goes up
        }
        
        // Check if bird has fallen below the threshold
        if (isAlive && transform.position.y < -10f)
        {
            Die();
        }
    }

    // Called when the bird collides with another object. Triggers death sequence.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAlive) return;   // prevents double-triggering
        isAlive = false;

        // Trigger camera shake effect if available
        if (cameraShake != null)
            cameraShake.Shake(0.3f, 0.3f);

        // Trigger lose screen after delay
        if (logic != null)
            logic.LoseAfterDelay(1f);
    }
}
