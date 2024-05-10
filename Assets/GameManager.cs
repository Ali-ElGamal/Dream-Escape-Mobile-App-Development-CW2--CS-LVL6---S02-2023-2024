using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);

        // Freeze the scene by setting the time scale to 0
        Time.timeScale = 0f;
    }
    public void restart()
    {
        Debug.Log("Restarting scene...");

        // Reset the time scale to 1
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        Debug.Log("Going to MainMenu scene...");

        // Reset the time scale to 1
        Time.timeScale = 1f;

        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }
}
