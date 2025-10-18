using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;                 // 1 = Easy, 2 = Hard
    private Button button;
    private GameManager2 gameManager;

    void Start()
    {
        button = GetComponent<Button>();

        // Find the GameManager2 in the scene
        gameManager = GameObject.Find("GameManager2").GetComponent<GameManager2>();

        if (button != null)
            button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        if (gameManager != null)
        {
            Debug.Log(button.gameObject.name + " clicked. Difficulty: " + difficulty);
            gameManager.StartGame(difficulty);
        }
        else
        {
            Debug.LogError("GameManager2 not found!");
        }
    }
}

