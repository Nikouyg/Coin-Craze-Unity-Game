using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
     public GameObject obstaclePrefab;
    private Vector3 spawnPos= new Vector3(33,5,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
