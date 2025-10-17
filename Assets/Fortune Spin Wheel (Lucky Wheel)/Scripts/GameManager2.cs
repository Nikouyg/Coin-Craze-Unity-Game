using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager2 : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public TextMeshProUGUI gameTitleText;

    [Header("Settings")]
    public float titleDisplayTime = 2f; // Time in seconds to show the title

    void Start()
    {
        // Hide Game Over UI and Restart button at the start
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        if (restartButton != null)
            restartButton.gameObject.SetActive(false);

        // Show title initially and hide it after delay
        if (gameTitleText != null)
            StartCoroutine(HideTitle());

        // Add listener to Restart button
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
    }

    IEnumerator HideTitle()
    {
        yield return new WaitForSeconds(titleDisplayTime);
        if (gameTitleText != null)
            gameTitleText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        // Show Game Over text and Restart button
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

        if (restartButton != null)
            restartButton.gameObject.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Resume time
        Time.timeScale = 1f;

        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
