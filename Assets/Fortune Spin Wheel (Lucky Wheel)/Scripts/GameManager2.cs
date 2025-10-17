using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ✅ Needed for restarting scenes

public class GameManager2 : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
       public TextMeshProUGUI gameTitleText;

    void Start()
    {
        // Hide Game Over UI at the start
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Add listener for restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    public void GameOver()
    {
        // Show Game Over UI
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        // Optionally pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Unpause time and reload current scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
