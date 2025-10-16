using UnityEngine;

public class SpawnManagerExtra : MonoBehaviour
{
    public GameObject coinPrefab;
    private float startDelay = 5f;
    private float repeatRate = 5f;
    private PlayerController playerControllerScripts;

    void Start()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnCoin", startDelay, repeatRate);
    }

    void SpawnCoin()
    {
        if (playerControllerScripts != null && !playerControllerScripts.gameOver)
        {
            float randomY = Random.Range(1f, 3f); // random height
            Vector3 spawnPosition = new Vector3(25f, randomY, 0f); // x = 25 ahead of player
            Instantiate(coinPrefab, spawnPosition, coinPrefab.transform.rotation);
        }
    }
}

