using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
     public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20, 5, 0);
     private float startDelay=4;
    private float repeatRate=3;
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
        
            Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);



    }
}
