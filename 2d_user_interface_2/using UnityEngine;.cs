using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Change to your game scene name
    }

    void OpenSettings()
    {
        Debug.Log("Open Settings - Implement Settings Panel Here");
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
