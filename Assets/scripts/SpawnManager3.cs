using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
     public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20, 0, 0);
     private float startDelay=3;
    private float repeatRate = 3;
     private PlayerController PlayerControllerScripts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
         
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        
         
            if(PlayerControllerScripts.gameOver==false){
            Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);


        }

        }

    }

