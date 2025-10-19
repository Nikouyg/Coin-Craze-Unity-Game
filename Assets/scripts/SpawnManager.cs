using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 4f;        // Starting spawn rate
    public float minSpawnRate = 1f;     // Minimum time between spawns
    public float spawnAcceleration = 0.01f; // How much spawnRate decreases per second

    private float nextSpawnTime = 0f;

    void Update()
    {
        // Spawn obstacles at current spawnRate
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(obstaclePrefab, new Vector3(20, 0, 0), obstaclePrefab.transform.rotation);
            nextSpawnTime = Time.time + spawnRate;
        }

        // Gradually increase difficulty by reducing spawnRate
        if (spawnRate > minSpawnRate)
        {
            spawnRate -= spawnAcceleration * Time.deltaTime;
            spawnRate = Mathf.Max(spawnRate, minSpawnRate); // clamp to minSpawnRate
        }
    }

    // Optional: instant hard mode
    public void SetHardMode()
    {
        spawnRate = 2f;
        Debug.Log("Hard mode activated! Spawn rate: " + spawnRate);
    }
}
