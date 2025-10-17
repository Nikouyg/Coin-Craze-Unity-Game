using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
          gameOverText.gameObject.SetActive(true);
    }
    
}
