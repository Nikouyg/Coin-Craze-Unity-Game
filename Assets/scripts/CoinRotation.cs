using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,rotationSpeed);  
    }
}
