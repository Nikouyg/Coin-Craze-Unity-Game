using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject coinPrefab;
    private Vector3 spawnPos = new Vector3(10, 0, 0);
    private float startDelay = 3f;
    private float repeatRate = 3f;
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
        // ✅ Only spawn if the game is not over
        if (PlayerControllerScripts != null && !PlayerControllerScripts.gameOver)
        {
            Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
        }
    }
}

