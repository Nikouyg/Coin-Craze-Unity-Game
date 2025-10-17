using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20, 5, 0);
    private float startDelay = 5f;
    private float repeatRate = 4f;
    private PlayerController PlayerControllerScripts;

    void Start()
    {
        // ✅ Find player and get its PlayerController component
        PlayerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();

        // ✅ Start spawning obstacles
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
        // ✅ Stop spawning when game is over
        if (PlayerControllerScripts != null && PlayerControllerScripts.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }

    void SpawnObstacle()
    {
        // ✅ Only spawn if the game is not over
        if (PlayerControllerScripts != null && !PlayerControllerScripts.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}

    
  