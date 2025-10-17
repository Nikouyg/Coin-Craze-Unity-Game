using UnityEngine;

public class MoveLeft3 : MonoBehaviour
{
    public float speed = 20f;          // How fast the coin moves left
    private float rotationSpeed = 300f; // How fast the coin spins

    void Update()
    {
        // 1️⃣ Move left in WORLD space (always straight)
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        // 2️⃣ Spin around the Y-axis in LOCAL space
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
