using UnityEngine;
using UnityEngine.SceneManagement;
using MyGameNamespace;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private GameTimer gameTimer; // Reference to the GameTimer script

    void Start()
    {
        // Ensure the game over screen is initially disabled
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);

        // Find the GameTimer script in the scene
        gameTimer = FindObjectOfType<GameTimer>();
        if (gameTimer == null)
        {
            Debug.LogError("GameTimer not found in the scene! Make sure the GameTimer script is attached to a GameObject.");
        }
    }

    public void GameOver()
    {
        // Display the game over screen
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        // Reset the timer
        if (gameTimer != null)
            gameTimer.ResetTimer();

        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
