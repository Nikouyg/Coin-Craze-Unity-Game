using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public float speed = 15f; // match background scroll speed
    private float leftBound = -10f; // destroy after leaving visible screen

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

       // if(transform.position.x < leftBound)
       // {
        // Destroy(gameObject);
       // }
    }
}
