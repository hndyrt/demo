using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PumkinCounter : MonoBehaviour
{
    [Tooltip("_sceneToLoadOnPlay is the name of the scene that will be loaded when users click play")]
    public string _sceneToLoadOnPlay = "Level"; // The default scene to load after game completion
    public static PumkinCounter instance;
    public TMP_Text PumkinText;
    public int currentPumkin = 0;
    public GameObject gameCompletionUI;
    public int pumkinTarget = 100; // Target number of pumpkins to complete the game
    UnityEngine.SceneManagement.Scene scene;

    void Awake()
    {
        instance = this;
        
        // Save the current scene name when the game starts
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        PlayerPrefs.SetString("_LastScene", scene.name);  // Store the current scene
        //Debug.Log(scene.name);
    }

    void Start()
    {
        PumkinText.text = "Focus Pumkin: " + currentPumkin.ToString();
    }

    public void IncreasePumkin(int v)
    {
        currentPumkin += v;
        PumkinText.text = "Focus Pumkin: " + currentPumkin.ToString();
        
        // Check if the player has met the pumpkin target to complete the game
        if (currentPumkin >= pumkinTarget)
        {
            CompleteGame();
        }
    }

    private void CompleteGame()
    {
        if (gameCompletionUI != null)
        {
            gameCompletionUI.SetActive(true); // Show the game completion UI
        }

        // (Optional) Pause the game
        Time.timeScale = 0f;
        Debug.Log("Game Completed!");

        // Load the next scene after a delay, or immediately if you prefer
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        // Optional: Add a delay to let the completion UI be visible before transitioning
        yield return new WaitForSeconds(2f); // Adjust the delay as needed

        // You can now load the scene from the stored PlayerPrefs or use _sceneToLoadOnPlay
        string nextScene = PlayerPrefs.GetString("_LastScene", _sceneToLoadOnPlay);  // Default to _sceneToLoadOnPlay if no last scene is saved
        SceneManager.LoadScene(nextScene);
    }
}