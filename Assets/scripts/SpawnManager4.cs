using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject obstaclePrefab;    // Your obstacle
    public GameObject powerUpPrefab;     // Your new power-up

    [Header("Spawn Settings")]
    public float spawnRate = 4f;         // How often to spawn (seconds)
    public float powerUpChance = 0.15f;  // 15% chance to spawn a power-up
    public Vector3 spawnPosition = new Vector3(20f, 0f, 0f);

    private float nextSpawnTime;

    void Update()
    {
        // Don't spawn if game is paused
        if (Time.timeScale == 0f) return;

        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObject()
    {
        float randomValue = Random.value;

        if (powerUpPrefab != null && randomValue < powerUpChance)
        {
            // Spawn power-up a little higher
            Vector3 pos = spawnPosition + new Vector3(0, 0.5f, 0);
            Instantiate(powerUpPrefab, pos, Quaternion.identity);
            Debug.Log("✨ Spawned Power-Up at " + pos);
        }
        else
        {
            // Spawn normal obstacle
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }

    // Optional: make game harder
    public void SetHardMode()
    {
        spawnRate = Mathf.Max(1f, spawnRate * 0.5f);
        Debug.Log("⚡ Hard Mode: Faster spawn rate = " + spawnRate);
    }
}
