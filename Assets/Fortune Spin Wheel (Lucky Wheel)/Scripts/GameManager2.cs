using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject titleScreen;             // Panel containing title + difficulty buttons
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    [Header("Gameplay")]
    public SpawnManager spawnManager;          // Reference to your SpawnManager

    void Start()
    {
        // Pause the game at the start
        Time.timeScale = 0f;

        // Show title/difficulty panel
        if (titleScreen != null)
            titleScreen.SetActive(true);

        // Hide Game Over and Restart button
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    // Called by Difficulty Buttons
    public void StartGame(int difficulty)
    {
        // Hide title screen
        if (titleScreen != null)
            titleScreen.SetActive(false);

        // Unpause the game
        Time.timeScale = 1f;

        // Adjust obstacle spawn rate based on difficulty
        if (spawnManager != null)
        {
            if (difficulty == 1) // Easy
                spawnManager.spawnRate = 4f;   // default
            else if (difficulty == 2) // Hard
                spawnManager.spawnRate = 2f;   // faster
        }
    }

    public void GameOver()
    {
        // Show Game Over UI and Restart button
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

        if (restartButton != null)
            restartButton.gameObject.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Resume time and reload the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

