using UnityEngine;
using UnityEngine.SceneManagement;
using MyGameNamespace;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public string MapScene; // Name of the scene to restart to
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
        Debug.Log("Restarting game..."); // Add debug log

        // Reset the timer
        if (gameTimer != null)
            gameTimer.ResetTimer();

        // Reload the specified scene to restart the game
        SceneManager.LoadScene(MapScene);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
