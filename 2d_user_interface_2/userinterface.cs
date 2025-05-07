using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPreviousScene : MonoBehaviour
{
    public void OnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No previous scene to load.");
        }
    }
}