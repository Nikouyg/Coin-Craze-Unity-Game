using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // TMP text
    public int coinCount;

    void Start()
    {
        // optional: initialize
        scoreText.text = "Coin Count: 0";
    }

    void Update()
    {
        scoreText.text = ": " + coinCount.ToString();
    }
}
