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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength; // represents 0,1, goes up
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (cameraShake != null)
        {
            cameraShake.Shake(0.3f, 0.3f);
        }
        logic.gameOver();
        isAlive = false;
    }
}
