using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 4f; // default spawn rate
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(obstaclePrefab, new Vector3(20, 0, 0), obstaclePrefab.transform.rotation);
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    // Method to increase difficulty
    public void SetHardMode()
    {
        spawnRate = 2f; // spawn obstacles faster
        Debug.Log("Hard mode activated! Spawn rate: " + spawnRate);
    }
}
