using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private int _nextLevelIndex = 1;
    [SerializeField] private int _mainMenuIndex = 0;

    public void StartNextLevel()
    {
        SceneManager.LoadScene(_nextLevelIndex);
        Time.timeScale = 1f;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuIndex);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
