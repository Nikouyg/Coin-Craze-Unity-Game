using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject coinPrefab;
    private Vector3 spawnPos = new Vector3(21, 1, 0);
    private float startDelay = 5f;
    private float repeatRate = 5f;
    private PlayerController PlayerControllerScripts;

    void Start()
    {
        // ✅ Find player and get its PlayerController component
        PlayerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();

        // ✅ Start spawning obstacles
        InvokeRepeating("SpawnCoin", startDelay, repeatRate);
    }

    void Update()
    {
        // ✅ Stop spawning when game is over
        if (PlayerControllerScripts != null && PlayerControllerScripts.gameOver)
        {
            CancelInvoke("SpawnCoin");
        }
    }

    void SpawnCoin()
    {
        if (PlayerControllerScripts != null && !PlayerControllerScripts.gameOver)
        {
            // Fixed spawn position at height 0.5
            Vector3 spawnPos = new Vector3(10, 0.5f, 0);
            Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
        }
    }
}


