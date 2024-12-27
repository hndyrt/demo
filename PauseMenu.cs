using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Reference to the pause menu UI panel
    public GameObject pauseMenuUI;
    
    // Boolean to track if the game is paused
    private bool isPaused = false;

    void Update()
    {
        // Kiểm tra nếu phím Escape được nhấn
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed!"); // In thông báo khi nhấn Esc
            if (isPaused)
            {
                Resume(); // Tiếp tục game
            }
            else
            {
                Pause(); // Tạm dừng game
            }
        }
    }

    // Function to pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Stop game time (pause the game)
        isPaused = true; // Set paused state to true
    }

    // Function to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time (unpause the game)
        isPaused = false; // Set paused state to false
    }

    // Function to restart the game
    public void Restart()
    {
        Time.timeScale = 1f; // Ensure game time is running
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Function to quit the game
    public void Quit()
    {
        Time.timeScale = 1f; // Ensure game time is running
        Application.Quit(); // Exit the game
    }
}