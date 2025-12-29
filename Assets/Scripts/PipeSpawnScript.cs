using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    [Header("Star Spawning")]
    public GameObject starPrefab;

    [Range(0f, 1f)]
    public float starSpawnChance = 0.5f; // 50% chance each pipe spawn

    public float starYOffsetRange = 2f;  // random Y inside the gap (tune this)

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        // Increment timer until spawn rate is reached
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Spawn a new pipe and reset timer
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        // Calculate random spawn height within offset range
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Spawn the pipe at random height
        Vector3 pipePos = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        GameObject newPipe = Instantiate(pipe, pipePos, transform.rotation);

        // Randomly spawn a star based on spawn chance
        if (starPrefab != null && Random.value < starSpawnChance)
        {
            // Position star with slight Y offset from pipe
            Vector3 starPos = pipePos + new Vector3(0f, Random.Range(-starYOffsetRange, starYOffsetRange), 0f);
            GameObject star = Instantiate(starPrefab, starPos, Quaternion.identity);

            // Make star move with the pipe
            star.transform.SetParent(newPipe.transform);
        }
    }
}
