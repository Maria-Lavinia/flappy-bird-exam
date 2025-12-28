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
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength; // represents 0,1, goes up
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAlive) return;   // prevents double-triggering
        isAlive = false;

        if (cameraShake != null)
            cameraShake.Shake(0.3f, 0.3f);

        if (logic != null)
            logic.LoseAfterDelay(1f);
    }
}
