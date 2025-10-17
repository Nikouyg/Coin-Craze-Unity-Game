using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
